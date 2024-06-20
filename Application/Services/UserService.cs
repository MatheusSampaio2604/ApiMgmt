using Application.Services.Interfaces;
using Application.ViewModels;
using Domain.Models.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : InterUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(RequestCreateUser createUser)
        {
            var user = new ApplicationUser
            {
                UserName = createUser.Name,
                NormalizedUserName = createUser.Name.ToUpper(),
                Email = createUser.Email,
                NormalizedEmail = createUser.Email.ToUpper(),
                Name = createUser.Name,
                DateRegister = DateTime.UtcNow,
                EmailConfirmed = true,
            };
            return await _userManager.CreateAsync(user, createUser.Password);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }
    }
}