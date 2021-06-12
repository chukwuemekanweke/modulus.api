using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.Utils
{
    public class CurrentDate
    {
        public DateTime CurrentDateTime { get; }
        public double TimeStamp { get; }

        public CurrentDate(DateTime currentDateTime, double timeStamp) => (CurrentDateTime, TimeStamp) = (currentDateTime, timeStamp);

    }
}
