using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service
{
    public class ExcelReaderService
    { 
    
        public async Task ParseFile(IFormFile formFile)
        {
            using (var stream = formFile.OpenReadStream())
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    DataSet dataSet = reader.AsDataSet();

                    if(dataSet.Tables.Count>2)
                    {
                        throw new InvalidOperationException("Only One Sheet Is Allowed In Payroll CSV");
                    }                   
                    DataTable staffpayrollData = dataSet.Tables[0];
                    string tableName = staffpayrollData.TableName;
                    for (int i = 1; i < staffpayrollData.Rows.Count; i++)
                    {
                        DataRow row = staffpayrollData.Rows[i];
                        string staffName = row.ItemArray[0] as string;
                        string staffEmail = row.ItemArray[1] as string;
                        string staffWalletAddress = row.ItemArray[2] as string;
                        string staffSalary = row.ItemArray[3] as string;
                        string position = row.ItemArray[4] as string;
                    }

                    DataTable payrollScheduleInfo = dataSet.Tables[1];
                    tableName = staffpayrollData.TableName;

                }
            }
        }
    }
}
