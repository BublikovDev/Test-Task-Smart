using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Requests.TypeOfEquipment
{
    public class UpdateTypeOfEquipmentRequest
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Area { get; set; }
    }
}
