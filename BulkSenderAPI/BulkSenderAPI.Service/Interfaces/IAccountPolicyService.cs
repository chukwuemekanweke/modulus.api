using System;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Implementations.Interfaces
{
    public interface IAccountPolicyService
    {
        Task<bool> IsAuthorisedToApprovePayrollScheduleAsync(string userId, Guid companyId);
        Task<bool> IsAuthorisedToCreatePayrollScheduleAsync(string userId, Guid companyId);
    }
}