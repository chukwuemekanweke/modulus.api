using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.ServiceModels
{
    public class UploadPayrollRequest
    {
        public string UserId { get; set; }
        public Guid CompanyId { get; set; }
        public IFormFile FormFile { get; set; } 
    }
}
