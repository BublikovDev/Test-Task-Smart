using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Responses.ProductionPremises
{
    public class ReadAllProductionPremisesResponse
    {
        public List<Shared.Models.ProductionPremises> ProductionPremises { get; set; }
    }
}
