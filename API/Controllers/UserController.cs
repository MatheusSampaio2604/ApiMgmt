using Application.Services;
using Application.Services.Interfaces;
using Asp.Versioning;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly InterUserService _userService;
        private readonly InterEmailService _emailService;

        public UserController(InterUserService userService, InterEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RequestCreateUser model)
        {
            try
            {
                var result = await _userService.CreateUserAsync(model);
                if (result.Succeeded)
                    return Ok("User created successfully");

                return BadRequest(result.Errors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            try
            {
                var token = await _userService.GeneratePasswordResetTokenAsync(email);
                if (token == null)
                    return BadRequest("Invalid email address");

                var callbackUrl = Url.Action(
                    "ResetPassword",
                    "Account",
                    new { token, email },
                    protocol: HttpContext.Request.Scheme);

                var subject = "Reset Password";
                var message = $"Please reset your password by clicking <a href='{callbackUrl}'>here</a>.";

                await _emailService.SendEmailAsync(email, subject, message);

                return Ok("Reset password link has been sent to your email.");
            }
            catch (Exception)
            {
                return BadRequest("Invalid email address");
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(RequestResetPassword model)
        {
            try
            {
                var result = await _userService.ResetPasswordAsync(model.Email, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    return Ok("Password reset successfully");
                }

                return BadRequest(result.Errors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
