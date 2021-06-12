using AutoMapper;
using BulkSenderAPI.Data;
using BulkSenderAPI.Model.Entities;
using BulkSenderAPI.Model.Enums;
using BulkSenderAPI.Model.Exceptions;
using BulkSenderAPI.Model.ServiceModels;
using BulkSenderAPI.Service.Extensions;
using BulkSenderAPI.Service.Implementations.Interfaces;
using BulkSenderAPI.Service.Interfaces;
using BulkSenderAPI.Web3Integration;
using BulkSenderAPI.Web3Integration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;
        private readonly Web3Utility _web3Utility;

        public PayrollScheduleUploadService(Web3Utility web3Utility,IUserService userService,IAccountPolicyService accountPolicyService,IExcelReaderService excelReaderService,IUnitOfWork unitOfWork, IMapper mapper, IServiceFactory serviceFactory) : base(unitOfWork, mapper, serviceFactory)
        {
            _excelReaderService = excelReaderService;
            _accountPolicyService = accountPolicyService;
            _userService = userService;
            _web3Utility = web3Utility;
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
                Staff entity = await _unitOfWork.GetRepository<Staff>().SingleAsync(x => x.EntityStatus== EntityStatus.Active && x.User.NormalizedEmail == staffNormalizedEmail);
                ValidWalletAddressResponse validWalletAddressResponse = _web3Utility.IsValidAddress(staff.WalletAddress);

                if (entity == null)
                {
                    
                    if(!validWalletAddressResponse.IsValid)
                    {
                        throw new InvalidOperationException($"{staff.WalletAddress} is an invalid address");
                    }

                    bool isWalletAlreadyBeingUsed = await IsWalletUsedByAnother(validWalletAddressResponse.CheckSumAddress);
                    if (!isWalletAlreadyBeingUsed)
                    {
                        throw new InvalidOperationException($"Wallet address for {entity.User.GetFullName()} is already in use");
                    }

                    isWalletAlreadyBeingUsed = await IsWalletUsedByAnyCompany(validWalletAddressResponse.CheckSumAddress);
                    if (!isWalletAlreadyBeingUsed)
                    {
                        throw new InvalidOperationException($"Wallet address for {entity.User.GetFullName()} is already in use");
                    }

                    Guid staffDesignationId = await GetStaffDesignationAsync(request.CompanyId, staff.Position);
                    string userId = await _userService.GetOrCreateUserAsync(staff.Email, staff.Name);


                    entity = new Staff
                    {
                        EntityStatus = EntityStatus.Active,
                        Chain = payrollSchedule.PayrollInfo.Blockchain,
                        CompanyId = request.CompanyId,
                        UserId = userId,
                        StaffDesignationId = staffDesignationId,
                        WalletAddress = validWalletAddressResponse.CheckSumAddress
                    };
                    _unitOfWork.GetRepository<Staff>().AddAndSetTimeStamp(entity);
                }
                else
                {
                    if(!string.Equals( entity.WalletAddress, validWalletAddressResponse.CheckSumAddress))
                    {
                        throw new InvalidOperationException($"There is a payment wallet mismatch on {entity.User.GetFullName()} account");
                    }
                }
            }

            await _unitOfWork.SaveChangesAsync();


        }

        private async Task<Guid> GetStaffDesignationAsync(Guid companyId, string position)
        {
            StaffDesignation staffDesignation =await _unitOfWork.GetRepository<StaffDesignation>().SingleAsync(x => x.CompanyId == companyId && x.Position == position);
            if (staffDesignation == null)
            {
                throw new InvalidOperationException($"Staff Designation Of {position} Has Not Been Registered Under This Company");
            }
            else
            {
                return staffDesignation.Id;
            }
        }

        private async Task<bool> IsWalletUsedByAnother(string walletAddress)
        {
           int staffUsingThisAddress = await  _unitOfWork.GetRepository<Staff>().GetQueryableList(x => x.EntityStatus == EntityStatus.Active).CountAsync();
           return staffUsingThisAddress >= 1 ? true : false;
        }

        private async Task<bool> IsWalletUsedByAnyCompany(string walletAddress)
        {
            int companyUsingThisAddress = await _unitOfWork.GetRepository<Company>().GetQueryableList(x => x.CompanyWalletAddress== walletAddress && x.EntityStatus == EntityStatus.Active).CountAsync();
            return companyUsingThisAddress >= 1 ? true : false;
        }
    }
}
