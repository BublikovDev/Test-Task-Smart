using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;
using Shared.Models.Requests.ProductionPremises;
using Shared.Models.Responses.ProductionPremises;
using System.Text.RegularExpressions;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPremisesController : Controller
    {
        private readonly AppDbContext _dataContext;

        public ProductionPremisesController(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductionPremisesRequest request)
        {
            try
            {
                var newObj = new ProductionPremises() 
                { 
                    Name = request.Name, 
                    EquipmentArea = request.EquipmentArea 
                };

                await _dataContext.ProductionPremises.AddAsync(newObj);
                await _dataContext.SaveChangesAsync();

                var response = new CreateProductionPremisesResponse() { ProductionPremisesId = newObj.Id };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> ReadAll()
        {
            try
            {
                var productionPremises = await _dataContext.ProductionPremises.ToListAsync();
                if(productionPremises.Count== 0)
                    return NotFound("Production premises not found");

                var response = new ReadAllProductionPremisesResponse() { ProductionPremises = productionPremises };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            try
            {
                var productionPremise = await _dataContext.ProductionPremises.FindAsync(id);
                if (productionPremise == null)
                    return NotFound("Production premise not found");

                var response = new ReadByIdProductionPremisesResponse() { ProductionPremise = productionPremise };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductionPremisesRequest request)
        {
            try
            {
                var obj = await _dataContext.ProductionPremises.FindAsync(request.Id);

                if (obj == null)
                    throw new Exception("Request is empty");

                if(!string.IsNullOrEmpty(request.Name))
                    obj.Name = request.Name;
                if(!double.IsNaN(request.EquipmentArea)&&request.EquipmentArea!=0)
                    obj.EquipmentArea = request.EquipmentArea;
                
                await _dataContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var productionPremise = await _dataContext.ProductionPremises.FindAsync(id);
                if (productionPremise == null)
                    return NotFound("Production premise not found");

                _dataContext.ProductionPremises.Remove(productionPremise);
                await _dataContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
