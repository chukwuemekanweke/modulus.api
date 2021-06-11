using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.ServiceModels
{
    public class ParsedStaff
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string WalletAddress { get; set; }
        public decimal Amount { get; set; }
    }

    public class PayrollInfo
    {

    }
}
