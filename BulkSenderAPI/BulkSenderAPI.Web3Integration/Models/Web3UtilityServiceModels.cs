using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Web3Integration.Models
{
    public class ValidWalletAddressResponse
    {
        public bool IsValid { get; set; }
        public string CheckSumAddress { get; set; }

        public ValidWalletAddressResponse(bool isValid, string checkSumAddress)
        {
            IsValid = isValid;
            CheckSumAddress = checkSumAddress;
        }
    }
}
