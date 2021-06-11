using BulkSenderAPI.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public double CreatedAtTimeStamp { get; set; }
        public double UpdatedAtTimeStamp { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EntityStatus EntityStatus { get; set; }
    }
}
