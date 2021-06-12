using BulkSenderAPI.Model.Utils;
using BulkSenderAPI.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Utils
{
    public static class DateUtilities
    {
        public static CurrentDate GetCurrentDate()
        {
            DateTime currentDateTime = DateTime.UtcNow;
            double timeStamp = currentDateTime.ToTimeStamp();
            CurrentDate currentDate = new CurrentDate(currentDateTime, timeStamp);
            return currentDate;
        }
    }
}
