using BulkSenderAPI.Model.Entities;
using BulkSenderAPI.Model.ServiceModels;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Implementations.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(CreateUserRequest request);
        Task<string> CreateUserAsync(string email, string name);
        Task<bool> DoesUserExistAsycn(string email);
        Task<ApplicationUser> GetUserAsync(string email);
        Task<string> GetOrCreateUserAsync(string email, string name);
    }
}