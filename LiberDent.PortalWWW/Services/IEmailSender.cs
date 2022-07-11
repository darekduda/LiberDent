using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.PortalWWW.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(List<string> emails, string subject, string message);
        Task SendEmailAsync(string emails, string subject, string message);
    }
}
