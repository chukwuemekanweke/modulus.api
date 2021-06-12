using BulkSenderAPI.Model.ServiceModels;
using BulkSenderAPI.Model.Utils;
using BulkSenderAPI.Service.Interfaces;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BulkSenderAPI.Model.Enums;

namespace BulkSenderAPI.Service
{
    public class ExcelReaderService : IExcelReaderService
    {

        public async Task<ParsedPayrollSchedule> ParseFileAsync(IFormFile formFile)
        {

            using (var stream = formFile.OpenReadStream())
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    ParsedPayrollSchedule parsedPayrollSchedule = new ParsedPayrollSchedule();
                    List<ParsedStaff> parsedStaff = new List<ParsedStaff>();
                    ParsedPayrollInfo parsedPayrollInfo = null;

                    DataSet dataSet = reader.AsDataSet();

                    if (dataSet.Tables.Count > 2)
                    {
                        throw new InvalidOperationException("Only One Sheet Is Allowed In Payroll CSV");
                    }
                    DataTable staffpayrollData = dataSet.Tables[0];
                    string tableName = staffpayrollData.TableName;
                    if (Constants.STAFF_PAYROLL_TABLE_NAME != tableName)
                        throw new InvalidOperationException("Invalid Sheet Name");

                    for (int i = 1; i < staffpayrollData.Rows.Count; i++)
                    {
                        DataRow row = staffpayrollData.Rows[i];

                        if (row.ItemArray.Length != 5)
                            throw new InvalidOperationException("Staff Payroll Sheet Column Count Does Not Match Expectations");

                        string staffName = row.ItemArray[0] as string;
                        string staffEmail = row.ItemArray[1] as string;
                        string staffWalletAddress = row.ItemArray[2] as string;
                        decimal staffSalary = decimal.Parse(row.ItemArray[3] as string);
                        string position = row.ItemArray[4] as string;
                        parsedStaff.Add(new ParsedStaff
                        {
                            Amount = staffSalary,
                            Email = staffEmail,
                            Name = staffName,
                            WalletAddress = staffWalletAddress
                        });
                    }

                    DataTable payrollScheduleInfo = dataSet.Tables[1];
                    tableName = staffpayrollData.TableName;
                    if (Constants.PAYROLL_SCHEDULE_TABLE_NAME != tableName)
                        throw new InvalidOperationException("Invalid Sheet Name");

                    for (int i = 0; i < payrollScheduleInfo.Rows.Count; i++)
                    {
                        DataRow row = staffpayrollData.Rows[i];
                        if (row.ItemArray.Length != 3)
                            throw new InvalidOperationException("payroll Schedule Sheet Column Count Does Not Match Expectations");
                        int dayOfPayment = int.Parse(row.ItemArray[0] as string);

                        decimal totalAmountForPayroll = decimal.Parse(row.ItemArray[1] as string);
                        Blockchain chain = (Blockchain)Enum.Parse(typeof(Blockchain), row.ItemArray[2] as string) ;

                        parsedPayrollInfo = new ParsedPayrollInfo
                        {
                            DayOfPayment = dayOfPayment,
                            TotalMonthlyPay = totalAmountForPayroll,
                            Blockchain = chain,
                            
                        };
                    }

                    return new ParsedPayrollSchedule
                    {
                        Staffs = parsedStaff,
                        PayrollInfo = parsedPayrollInfo,
                        FileCheckSum = CalculateCheckSum(formFile)
                    };


                }
            }
        }

        public string CalculateCheckSum(IFormFile formFile)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = formFile.OpenReadStream())
                {
                    return Encoding.Default.GetString(sha1.ComputeHash(stream));
                }
            }
        }
    }
}
