
using RushHour.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RushHour.Web.Mappings;
using RushHour.Web.App_Start;
using AutoMapper;
using RushHour.Web.ActionFilters;
using RushHour.RelationalServices.Domain.UserModels;
using RushHour.DataAccess.UnitOfWork;
using RushHour.Common.Interfaces;

namespace RushHour.Web.Controllers
{
    public class UserController : CrudController<User, UserViewModel>
    {
        private UnitOfWork unitOfWork = new UnitOfWork();



        public UserController(IService<User> service)
            : base(service)
        {

        }
        [IsAdmin]
        public override ActionResult Index()
        {

            return base.Index();
        }
        [IsAdmin]
        public override ActionResult LoadData()
        {
            return base.LoadData();
        }
        [IsAdmin]
        public override ActionResult Edit(int id)
        {
            return base.Edit(id);
        }

        public new ActionResult Edit(UserViewModel vModel, User model)
        {
            Mapper.Map(vModel, model);
            return View(model);
        }
        [IsAdmin]
        public override ActionResult Details(int id)
        {
            return base.Details(id);
        }
        [IsAdmin]
        public override ActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        public override ActionResult DeleteConfirmed(int id)
        {
            return base.DeleteConfirmed(id);
        }
    }
}