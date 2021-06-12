using AutoMapper;
using BulkSenderAPI.Data;
using BulkSenderAPI.Model.Entities;
using BulkSenderAPI.Model.Enums;
using BulkSenderAPI.Model.Utils;
using BulkSenderAPI.Service.Implementations.Interfaces;
using BulkSenderAPI.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Implementations
{
    public class AccountPolicyService : BaseService, IAccountPolicyService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountPolicyService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork, IMapper mapper, IServiceFactory serviceFactory) : base(unitOfWork, mapper, serviceFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<bool> IsAuthorisedToCreatePayrollScheduleAsync(string userId, Guid companyId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            Company company = await _unitOfWork.GetRepository<Company>().SingleAsync(x => x.EntityStatus == EntityStatus.Active && x.Id == companyId);
            if (company == null)
            {
                throw new Exception("Company does not exist");
            }

            Staff staff = await _unitOfWork.GetRepository<Staff>().SingleAsync(x => x.EntityStatus == EntityStatus.Active && x.CompanyId == companyId && x.UserId == user.Id);

            if (staff == null)
            {
                return false;
            }

            bool isAccountant = await _userManager.IsInRoleAsync(user, Constants.ACCOUNTANT_ROLE);
            bool isBusinessOwner = await _userManager.IsInRoleAsync(user, Constants.OWNER_ROLE);

            return isAccountant || isBusinessOwner;
        }

        public async Task<bool> IsAuthorisedToApprovePayrollScheduleAsync(string userId, Guid companyId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            Company company = await _unitOfWork.GetRepository<Company>().SingleAsync(x => x.EntityStatus == EntityStatus.Active && x.Id == companyId);
            if (company == null)
            {
                throw new Exception("Company does not exist");
            }

            Staff staff = await _unitOfWork.GetRepository<Staff>().SingleAsync(x => x.EntityStatus == EntityStatus.Active && x.CompanyId == companyId && x.UserId == user.Id);

            if (staff == null)
            {
                return false;
            }

            bool isBusinessOwner = await _userManager.IsInRoleAsync(user, Constants.OWNER_ROLE);

            return isBusinessOwner;
        }


    }
}
