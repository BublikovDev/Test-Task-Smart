using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Requests.ProductionPremises
{
    public class UpdateProductionPremisesRequest
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double EquipmentArea { get; set; }
    }
}
