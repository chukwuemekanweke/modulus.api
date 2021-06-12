using AutoMapper;
using BulkSenderAPI.Data;
using BulkSenderAPI.Model.Entities;
using BulkSenderAPI.Model.Exceptions;
using BulkSenderAPI.Model.ServiceModels;
using BulkSenderAPI.Service.Implementations.Interfaces;
using BulkSenderAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Implementations
{
    public class PayrollScheduleUploadService:BaseService
    {
        private readonly IExcelReaderService _excelReaderService;
        private readonly IAccountPolicyService _accountPolicyService;

        public PayrollScheduleUploadService(IAccountPolicyService accountPolicyService,IExcelReaderService excelReaderService,IUnitOfWork unitOfWork, IMapper mapper, IServiceFactory serviceFactory) : base(unitOfWork, mapper, serviceFactory)
        {
            _excelReaderService = excelReaderService;
            _accountPolicyService = accountPolicyService;
        }

        public async Task UploadAsync(UploadPayrollRequest request)
        {

            //todo: Validate Accountant role
            //todo: Get CheckSum and File Content
            //todo: Create Staff information if it doesn't exist
            //todo: Validate that all the staff addresses are wallet addresses
            //todo: Validate that the same address is not being used by another person in the company
            //todo: Validate that the same address is not being used by any other person on the platform
            //todo: Validate that the address of staff don't match any of our own self generated addresses for companies
            //todo: If a user already exists and there is a payment wallet address mismatch with what we have on payroll, flag that and revert
            //todo: Send email to all the company staff indicating their addition to the system and asking them to verify that we have the right address on payroll
            //todo: Generate signup link for the staff on our platform, with this all they need is to put their password to become a bonified user on the platform
            //todo: Notify the business owner about a new payroll schedule that needs his approval, also show summary about the new payroll schedule such as number of people on it as well as the monthly amount and payment date



            bool isAuthorised =  await _accountPolicyService.IsAuthorisedToCreatePayrollScheduleAsync(request.UserId, request.CompanyId);
            if (!isAuthorised)
            {
                throw new ForbiddenException("You lack the authorisation to create a payroll");
            }

           string checksum =  _excelReaderService.CalculateCheckSum(request.FormFile);
           ParsedPayrollSchedule payrollSchedule = await _excelReaderService.ParseFileAsync(request.FormFile);

            foreach (var staff in payrollSchedule.Staffs)
            {
                string staffNormalizedEmail = staff.Email.ToUpper();
                Staff entity = await _unitOfWork.GetRepository<Staff>().SingleAsync(x=>x.User.NormalizedEmail== staffNormalizedEmail)
                if (entity == null)
                {

                }
                else
                {

                }
            }


        }
    }
}
