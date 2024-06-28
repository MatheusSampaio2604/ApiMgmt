namespace Application.Services.Interfaces
{
    public interface InterEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
