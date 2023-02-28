using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int ProductionPremiseId { get; set; }
        public ProductionPremises? ProductionPremise { get; set; }
        public int TypeOfEquipmentId { get; set; }
        public TypeOfEquipment? TypeOfEquipment { get; set; }
        public int CountOfEquipment { get; set; }
    }
}
