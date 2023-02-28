using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Requests.ProductionPremises;
using Shared.Models.Responses.ProductionPremises;
using Shared.Models;
using Server.Data;
using Shared.Models.Requests.TypeOfEquipment;
using Shared.Models.Responses.TypeOfEquipment;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeOfEquipmentController : Controller
    {
        private readonly AppDbContext _dataContext;

        public TypeOfEquipmentController(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateTypeOfEquipmentRequest request)
        {
            try
            {
                var newObj = new TypeOfEquipment()
                {
                    Name = request.Name,
                    Area = request.Area
                };

                await _dataContext.TypesOfEquipment.AddAsync(newObj);
                await _dataContext.SaveChangesAsync();

                var response = new CreateTypeOfEquipmentResponse() { TypeOfEquipmentId = newObj.Id };

                return Ok(response);
            }
            catch (Exception ex)
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
                var typesOfEquipment = await _dataContext.TypesOfEquipment.ToListAsync();
                if (typesOfEquipment.Count == 0)
                    return NotFound("Types of equipment not found");

                var response = new ReadAllTypesOfEquipmentResponse() { TypesOfEquioment = typesOfEquipment };

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
                var typeOfEquipment = await _dataContext.TypesOfEquipment.FindAsync(id);
                if (typeOfEquipment == null)
                    return NotFound("Types of equipment not found");

                var response = new ReadByIdTypeOfEquipmentResponse() { TypeOfEquipment = typeOfEquipment };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateTypeOfEquipmentRequest request)
        {
            try
            {
                var obj = await _dataContext.TypesOfEquipment.FindAsync(request.Id);

                if (obj == null)
                    throw new Exception("Request is empty");

                if (!string.IsNullOrEmpty(request.Name))
                    obj.Name = request.Name;
                if (!double.IsNaN(request.Area) && request.Area != 0)
                    obj.Area = request.Area;

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
                var typeOfEquipment = await _dataContext.TypesOfEquipment.FindAsync(id);
                if (typeOfEquipment == null)
                    return NotFound("Type of equipment not found");

                _dataContext.TypesOfEquipment.Remove(typeOfEquipment);
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