using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Requests.TypeOfEquipment
{
    public class CreateTypeOfEquipmentRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Area { get; set; }
    }
}
