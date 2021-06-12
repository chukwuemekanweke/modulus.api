using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public string BusinessOwnerId { get; set; }
        public string BusinessAccountantId { get; set; }
        public decimal MaxMonthlyPayrollLimit { get; set; }
        public string CompanyWalletAddress { get; set; }
        public int HDWalletIndex { get; set; }

    }
}
