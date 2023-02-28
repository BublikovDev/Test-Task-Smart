using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Responses.Contract
{
    public class ReadContractResponse
    {
        public string NameOfProductionPremises { get; set; }
        public string NameOfTypeOfEquipment { get; set; }
        public int CountOfEquipment { get; set; }
    }
}
