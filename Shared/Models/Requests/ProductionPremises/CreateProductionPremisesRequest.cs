using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Requests.ProductionPremises
{
    public class CreateProductionPremisesRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double EquipmentArea { get; set; }
    }
}
