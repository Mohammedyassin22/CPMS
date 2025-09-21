using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.SecurityModules
{
    public static class EmailSetting
    {
        public static bool SendEmail(Email email)
        {
            try
            {
                var client = new SmtpClient("stmp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("moyassin200522@gmail.com", "rxhyglfglnuygdde");
                client.Send("moyassin200522@gmail.com", email.To, email.Subject, email.Body);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
