using BulkSenderAPI.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class PayrollPaymentBatch:BaseEntity
    {
        public int BatchId { get; set; }
        public string BatchCode { get; set; }
        public int NumberOfPeopleToPay { get; set; }
        public int NumberOfPeoplePaid { get; set; }
        public DateTime PaymentStartDate { get; set; }
        public DateTime PaymentCompletionDate { get; set; }
        public bool IsApproved { get; set; }
        public Blockchain Chain { get; set; }
        public Guid PayrollSchedule { get; set; }
    }
}
