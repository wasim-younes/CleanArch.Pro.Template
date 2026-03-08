using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string email, string name);
    }
}
