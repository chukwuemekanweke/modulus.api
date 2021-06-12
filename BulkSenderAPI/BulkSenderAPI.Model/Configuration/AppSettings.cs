using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Configuration
{
    public class AppSettings
    {
        public JwtConfiguration Jwt { get; set; }
    }


    public class JwtConfiguration
    {
        public string ServerSecret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpiresIn { get; set; }
    }
}
