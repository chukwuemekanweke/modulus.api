using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class StaffDesignation:BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string Position { get; set; }
    }
}
