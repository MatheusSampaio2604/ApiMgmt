using Application.Services.Interfaces;
using Application.ViewModels;
using Domain.Models.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UserService : InterUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(RequestCreateUser createUser)
        {
            createUser.Name = createUser.Name.TrimEnd().TrimStart();
            createUser.Email = createUser.Email.TrimEnd().TrimStart();

            ApplicationUser user = new()
            {
                UserName = createUser.Name.Replace(" ", "_"),
                NormalizedUserName = createUser.Name.ToUpper(),
                Email = createUser.Email,
                NormalizedEmail = createUser.Email.ToUpper(),
                Name = createUser.Name,
                DateRegister = DateTime.UtcNow,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, createUser.Password);

            if (result.Succeeded)
            {
                ApplicationUser userData = await _userManager.FindByEmailAsync(createUser.Email);
                await _userManager.AddToRoleAsync(userData, "User");

                var claims = new List<Claim>
                { new ("Permission", "View") };

                foreach (var claim in claims)
                    await _userManager.AddClaimAsync(userData, claim);
            }
            return result;
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

        public async Task<LoginResult> LoginAsync(string userName, string password)
        {
            var user = await _userManager.FindByEmailAsync(userName);

            user ??= await _userManager.FindByNameAsync(userName);

            if (user == null)
                return new LoginResult { Succeeded = false, Errors = new[] { "Invalid email or password" } };

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var claims = await _userManager.GetClaimsAsync(user);

                string token = GenerateJwtToken(user, roles, claims);
                return new LoginResult { Succeeded = true, Token = token, Name = user.Name };
            }
            else
                return new LoginResult { Succeeded = false, Errors = new[] { "Invalid email or password" } };
        }

        private string GenerateJwtToken(ApplicationUser user, IList<string> rolesUser, IList<Claim> claimsUser)
        {

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Name, user.UserName),
                new (ClaimTypes.Email, user.Email),
                new (ClaimTypes.Role, string.Join(",", rolesUser)),

            };

            claims.AddRange(claimsUser);


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("&secret-key&4002-8922$FromJanusAutomation$"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddHours(8);

            var token = new JwtSecurityToken(
            //    issuer: "your-website.com",
            //    audience: "your-website.com",
                claims: claims,
                expires: expires,
                signingCredentials: creds

            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}