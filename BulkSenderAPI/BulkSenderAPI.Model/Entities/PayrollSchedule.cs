using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class PayrollSchedule:BaseEntity
    {
        public string UploadedBy { get; set; }
        public string ExcelFileUrl { get; set; }
        public string FileIntegrityCheckSum { get; set; }
        public int DayOfPayment { get; set; }
        public Guid CompanyId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
    }
}
