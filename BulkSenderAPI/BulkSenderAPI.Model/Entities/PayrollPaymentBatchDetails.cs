using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class PayrollPaymentBatchDetails:BaseEntity
    {
        public Guid StaffId { get; set; }
        public Guid PayrollPaymentBatch { get; set; }
        public Guid? PaymentEventId { get; set; }
        public decimal AmountSent { get; set; }
        public string StaffWalletAddress { get; set; }
        public string TransactionHash { get; set; }



    }
}
