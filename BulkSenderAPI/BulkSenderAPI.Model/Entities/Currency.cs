using BulkSenderAPI.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Entities
{
    public class Currency:BaseEntity
    {
        public string ContractAddress { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}
