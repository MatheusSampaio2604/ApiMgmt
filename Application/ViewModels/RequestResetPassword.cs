namespace Application.ViewModels
{
    public class RequestResetPassword
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
        public required string NewPassword { get; set; }
    }
}
