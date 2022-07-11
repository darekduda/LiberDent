using LiberDent.PortalWWW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace LiberDent.PortalWWW.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Potwierdź swoje konto",
                $"Witaj! <br/>" +
                $"Założyłeś właśnie konto na naszej stronie. Cieszymy się bardzo." +
                $"Prosimy o potwierdzenie rejestracji. Wystarczy kliknąć w ten link <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
