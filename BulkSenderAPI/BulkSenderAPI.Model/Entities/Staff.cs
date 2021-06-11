using BulkSenderAPI.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class Staff:BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid StaffDesignationId { get; set; }
        public string WalletAddress { get; set; }
        public Blockchain Chain { get; set; }
    }
}
