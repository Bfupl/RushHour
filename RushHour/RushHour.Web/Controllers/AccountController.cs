using RushHour.BaseService;
using RushHour.Common.Interfaces;
using RushHour.DataAccess.Context;
using RushHour.DataAccess.UnitOfWork;
using RushHour.RelationalServices.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;





namespace RushHour.Web.Controllers
{
    public class AccountController : Controller
    {

        private IService<User> service;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public AccountController()
        {
            this.service = new BaseService<User>(unitOfWork);
        }
        private RushHourDbContext db = new RushHourDbContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            Authentication.AuthenticationManager.Authenticate(user.Email, user.Password);

            if (Authentication.AuthenticationManager.LoggedUser == null)
            {
                return View();
            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult LogOut()
        {
            Authentication.AuthenticationManager.Logout();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Email,Password,Name,Phone,IsAdmin")] ViewModels.UserViewModel model)
        {
            if (db.Users.Where(u => u.Email == model.Email).Count() > 0)
            {
                ModelState.AddModelError("", "A user with these credentials already exists.");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User();
            user.Email = model.Email;
            user.Password = model.Password;
            user.Name = model.Name;
            user.Phone = model.Phone;
            user.IsAdmin = model.IsAdmin;

            if (!service.Insert(user))
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}