using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface InterEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
