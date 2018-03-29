using RushHour.RelationalServices.Domain.ActivityModels;
using RushHour.RelationalServices.Domain.AppointmentModels;
using RushHour.RelationalServices.Domain.UserModels;
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
        private string viewAppointmentLink = "http://rushhour.apphb.com/Appointment";

       
        private string _adminEmail = "rushhourapp9@gmail.com";
        private string _adminPass = "!e123456789";

        public void SendContactFormEmail(string email, string name, string comment)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_adminEmail, _adminPass)
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(email)
                };
                mailMessage.To.Add(_adminEmail);
                mailMessage.Body = $"{ name} with email { email} send you the next comment: { comment}";
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "Email request...";
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                throw new ApplicationException($"Unable to load : '{ex.Message}'.");
            }
        }

       

        public void SendNewAppointmentEmail(User user, List<string> activities, Appointment appointment)
        {
            string callbackUrl = $"{viewAppointmentLink}";
            string link = $"<a href='{ callbackUrl}'>here</a>!";
            string activitiesInAppointment = string.Join(Environment.NewLine+ ",",activities);
            int range = appointment.EndDateTime.Hour - appointment.StartDateTime.Hour;


            SendEmail(user.Email, "Rush Hour - New Appointment Created",
                $"Hello  {user.Name} , you have added new Appointment in your Calendar " +
                $"with the following activities: {activitiesInAppointment} <br /> " + 
                $" || Start Date & Time of your Appointment ->  {appointment.StartDateTime} <br />" +
                $" || End Date & Time of your Appointment ->  {appointment.EndDateTime} <br />" +
                $" || Estimated time to complete your activities ->  {range} hours  <br /> " +
                $" || To view your all of your appointments click  -> {link}");
        }

        public void SendEmail(string email, string name, string comment)
        {

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_adminEmail, _adminPass)
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("rushour@gmail.com")
                };
                mailMessage.To.Add(email);
                mailMessage.Body = comment;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = name;
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                throw new ApplicationException($"Unable to load : '{ex.Message}'.");
            }
        }
    }
}

