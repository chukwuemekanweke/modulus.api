using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class StaffPaymentEvent:BaseEntity
    {
        public string ContractAddress { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }
        public decimal Amount { get; set; }
        public string BatchId { get; set; }
        public string TransactionHash { get; set; }
        public long BlockNumber { get; set; }
        public long BlockTimeStamp { get; set; }
    }
}
