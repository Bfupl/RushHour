using RushHour.NotificationService;
using RushHour.Web.ViewModels.EmailSending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RushHour.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(EmailSendingViewModel emailSendingViewModel)
        {
            EmailSender emailSender = new EmailSender();

            if (emailSendingViewModel.Email == null || emailSendingViewModel.Name == null || emailSendingViewModel.Comment == null)
            {
                TempData["Email"] = "You have to enter all the needed information for sending an email!";
                return View("Contact");
            }

            emailSender.SendContactFormEmail(emailSendingViewModel.Email, emailSendingViewModel.Name, emailSendingViewModel.Comment);
            TempData["Email"] = "You have send the email successfully!";

            return View("Contact");
        }
    }
}