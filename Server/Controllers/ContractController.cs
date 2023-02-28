using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Shared.Models.Requests.ProductionPremises;
using Shared.Models.Responses.ProductionPremises;
using Shared.Models;
using Shared.Models.Requests.Contract;
using Shared.Models.Responses.Contract;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : Controller
    {
        private readonly AppDbContext _dataContext;

        public ContractController(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateContractRequest request)
        {
            try
            {
                var productionPremise = await _dataContext.ProductionPremises.FindAsync(request.ProductionPremiseId);
                var typeOfEquipment = await _dataContext.TypesOfEquipment.FindAsync(request.TypeOfEquipmentId);

                if (productionPremise == null||typeOfEquipment==null)
                    return NotFound("Production premise or type of equipment not found");

                double countOfArea = typeOfEquipment.Area * request.CountOfEquipment;

                if (productionPremise.EquipmentArea - countOfArea < 0)
                    throw new Exception("Too much equipment");

                productionPremise.EquipmentArea -= countOfArea;

                var newObj = new Contract()
                {
                    ProductionPremiseId= productionPremise.Id,
                    TypeOfEquipmentId=typeOfEquipment.Id,
                    ProductionPremise=productionPremise,
                    TypeOfEquipment=typeOfEquipment,
                    CountOfEquipment=request.CountOfEquipment
                };

                await _dataContext.Contracts.AddAsync(newObj);

                await _dataContext.SaveChangesAsync();

                var response = new CreateContractResponse() { ContractId = newObj.Id };

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
                var contracts = await _dataContext.Contracts.Include(c => c.ProductionPremise).Include(c=>c.TypeOfEquipment).ToListAsync();
                if (contracts.Count == 0)
                    return NotFound("Contracts not found");

                List<ReadContractResponse> contratsResponse = new List<ReadContractResponse>();
                foreach (var contract in contracts)
                {
                    contratsResponse.Add(new ReadContractResponse()
                    {
                        NameOfProductionPremises = contract.ProductionPremise.Name,
                        NameOfTypeOfEquipment = contract.TypeOfEquipment.Name,
                        CountOfEquipment= contract.CountOfEquipment
                    });
                }

                var response = new ReadAllContractsResponse() { Contracts = contratsResponse };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
