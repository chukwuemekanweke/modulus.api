using BulkSenderAPI.Model.Entities;
using BulkSenderAPI.Model.Enums;
using BulkSenderAPI.Model.ServiceModels;
using BulkSenderAPI.Model.Utils;
using BulkSenderAPI.Service.Extensions;
using BulkSenderAPI.Service.Implementations.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Implementations
{
    public class UserService : IUserService
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> DoesUserExistAsycn(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            return user == null ? false : true;
        }

        public async Task<string> GetOrCreateUserAsync(string email,string name)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser == null)
            {
                return await CreateUserAsync(email, name);
            }
            else
            {
                return applicationUser.Id;
            }
        }

        public async Task<ApplicationUser> GetUserAsync(string email)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser == null)
            {
                throw new InvalidOperationException("User not found");
            }
            else
            {
                return applicationUser;
            }
        }

        public async Task<string> CreateUserAsync(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Email or name cannot be null");
            }

            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser != null)
            {
                throw new Exception("User already exists");
            }

            string[] names = name.Split(" ");
            string firstName = null;
            string lastname = null;
            string middleName = null;

            if (names.Length == 1)
            {
                firstName = names[0];
            }
            else if (names.Length == 2)
            {
                firstName = names[0];
                lastname = names[1];
            }
            else if (names.Length == 3)
            {
                firstName = names[0];
                middleName = names[1];
                lastname = names[2];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Only 3 names are allowed");
            }


            applicationUser = new ApplicationUser
            {
                EntityStatus = EntityStatus.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatedAtTimeStamp = DateTime.UtcNow.ToTimeStamp(),
                UpdatedAtTimeStamp = DateTime.UtcNow.ToTimeStamp(),
                Email = email,
                UserName = email,
                FirstName = firstName,
                OtherName = middleName,
                LastName = lastname,
                EmailConfirmed = false,
                HasVerifiedInformation = false,
                SignupLink = GenerateSignUpLink(email)
            };
            await _userManager.CreateAsync(applicationUser);
            return applicationUser.Id;
        }


        public async Task<string> CreateUserAsync(CreateUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentNullException("Email or name cannot be null");
            }

            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(request.Email);
            if (applicationUser != null)
            {
                throw new Exception("User already exists");
            }


            string[] names = request.Name.Split(" ");
            string firstName = null;
            string lastname = null;
            string middleName = null;

            if (names.Length == 1)
            {
                firstName = names[0];
            }
            else if (names.Length == 2)
            {
                firstName = names[0];
                lastname = names[1];
            }
            else if (names.Length == 3)
            {
                firstName = names[0];
                middleName = names[1];
                lastname = names[2];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Only 3 names are allowed");
            }


            applicationUser = new ApplicationUser
            {
                EntityStatus = EntityStatus.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatedAtTimeStamp = DateTime.UtcNow.ToTimeStamp(),
                UpdatedAtTimeStamp = DateTime.UtcNow.ToTimeStamp(),
                Email = request.Email,
                UserName = request.Email,
                FirstName = firstName,
                OtherName = middleName,
                LastName = lastname,
                EmailConfirmed = true,
                HasVerifiedInformation = true
            };
            await _userManager.CreateAsync(applicationUser, request.Password);
            return applicationUser.Id;
        }


        private string GenerateSignUpLink(string emailAddress)
        {
            return $"{Constants.BASE_URL}/api/v1/onboarding/completion?email=emailAddress";
        }










    }
}
