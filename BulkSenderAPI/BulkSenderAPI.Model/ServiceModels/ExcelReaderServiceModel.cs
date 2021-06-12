using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.ServiceModels
{

    public class ParsedPayrollSchedule
    {
        public IEnumerable<ParsedStaff> Staffs { get; set; }
        public ParsedPayrollInfo PayrollInfo { get; set; }
        public string FileCheckSum { get; set; }
    }



    public class ParsedStaff
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string WalletAddress { get; set; }
        public decimal Amount { get; set; }
    }

    public class ParsedPayrollInfo
    {
        public decimal TotalMonthlyPay { get; set; }
        public int DayOfPayment { get; set; }
    }
}
