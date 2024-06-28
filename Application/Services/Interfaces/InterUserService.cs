using Application.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Interfaces
{
    public interface InterUserService
    {
        Task<IdentityResult> CreateUserAsync(RequestCreateUser createUser);
        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword);
        Task<LoginResult> LoginAsync(string email, string password);
    }
}
