using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.NotificationService
{
    public class EmailSender
    {
        public SmtpClient Client { get; set; }

        //Send email using mailtrap.io
        public EmailSender()
        {
            Client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("039078f71a7058", "effa6599a23a7b"),
                EnableSsl = true
            };
        }

        public void SendMail(string from, string subject, string body)
        {
            Client.Send(from, "Sina1991@abv.bg", subject, body);
        }
    }
}

