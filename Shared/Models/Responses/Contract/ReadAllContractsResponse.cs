using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Responses.Contract
{
    public class ReadAllContractsResponse
    {
        public List<ReadContractResponse> Contracts { get; set; }
    }
}
