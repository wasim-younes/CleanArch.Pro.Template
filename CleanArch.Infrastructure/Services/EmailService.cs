using CleanArch.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public Task SendWelcomeEmailAsync(string email, string name)
        {
            Console.WriteLine($"[EMAIL SENT] To: {email}, Message: Welcome {name}!");
            return Task.CompletedTask;
        }
    }
}
