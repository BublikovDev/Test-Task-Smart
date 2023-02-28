using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Requests.Contract
{
    public class CreateContractRequest
    {
        [Required]
        public int ProductionPremiseId { get; set; }
        [Required]
        public int TypeOfEquipmentId { get; set; }
        [Required]
        public int CountOfEquipment { get; set; }
    }
}
