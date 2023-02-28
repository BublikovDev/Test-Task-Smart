using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ProductionPremises
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double EquipmentArea { get; set; }

        public List<Contract>? Contract { get; set; }
    }
}
