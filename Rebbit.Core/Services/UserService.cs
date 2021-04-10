using Microsoft.AspNetCore.Identity;
using Rebbit.Core.Entities;
using Rebbit.Core.Entities.Base;
using Rebbit.Core.Interfaces;
using Rebbit.Core.Interfaces.Services;
using Rebbit.Core.ValueObject;
using System;
using System.Threading.Tasks;

namespace Rebbit.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppLogger<UserService> _logger;

        public UserService(IAsyncRepository<User> userRepository, UserManager<ApplicationUser> userManager, IAppLogger<UserService> logger)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _logger = logger;
        }

        public async ValueTask<User> GetUserById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async ValueTask SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<User> SignUp(SignUpData signUpData)
        {
            ApplicationUser applicationUser = GetApplicationUser(signUpData);

            IdentityResult userCreationResult = await _userManager.CreateAsync(applicationUser, signUpData.Password);
            if (userCreationResult.Succeeded == false)
            {

            }

            User user = GetUser(signUpData, applicationUser);

            return await _userRepository.AddAsync(user);
        }

        private User GetUser(SignUpData signUpData, ApplicationUser applicationUser) => new User
        {
            ApplicationUser = applicationUser,
            JoinedAt = DateTime.Now,
            Username = signUpData.Username,
        };

        private ApplicationUser GetApplicationUser(SignUpData signUpData) => new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = signUpData.Email,
            UserName = signUpData.Username,
            EmailConfirmed = false,
        };
    }
}
