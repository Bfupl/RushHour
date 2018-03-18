using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RushHour.Web.ViewModels;
using System.Net;
using RushHour.Web.App_Start;
using AutoMapper;
using RushHour.Web.ActionFilters;
using RushHour.RelationalServices.Domain.ActivityModels;
using RushHour.Common.Interfaces;

namespace RushHour.Web.Controllers
{
    public class ActivityController : CrudController<Activity, ActivityViewModel>
    {
        public ActivityController(IService<Activity> service)
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
        public override ActionResult Create()
        {
            return base.Create();
        }

        public new ActionResult Create(ActivityViewModel model, Activity activity)
        {

            Mapper.Map(model, activity);

            return View(model);
        }
        [IsAdmin]
        public override ActionResult Edit(int id)
        {
            return base.Edit(id);
        }

        public new ActionResult Edit(ActivityViewModel vModel, Activity model)
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