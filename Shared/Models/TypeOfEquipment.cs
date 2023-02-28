using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class TypeOfEquipment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Area { get; set; }

        public List<Contract>? Contract { get; set; }
    }
}
