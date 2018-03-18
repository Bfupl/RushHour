using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RushHour.Web.ViewModels;
using System.Net;
using RushHour.Web.ViewModels.Appointment;
using AutoMapper;
using System.Web.Script.Serialization;
using RushHour.Web.ActionFilters;
using RushHour.RelationalServices.Domain.AppointmentModels;
using RushHour.Common.Interfaces;
using RushHour.RelationalServices.Domain.ActivityModels;

namespace RushHour.Web.Controllers
{
    public class AppointmentController : CrudController<Appointment, AppointmentCreateViewModel>
    {

        private IService<Activity> activityService;


        public AppointmentController(IService<Appointment> service, IService<Activity> activityService)
            : base(service)
        {
            this.activityService = activityService;

        }

        [IsLoggedUser]
        public override ActionResult Index()
        {
            return View();
        }

        [IsLoggedUser]
        public override ActionResult LoadData()
        {
            IEnumerable<Appointment> appointments = Authentication.AuthenticationManager.LoggedUser.IsAdmin ?
                service.GetAll() :
                service.GetAll(ap => ap.UserId == Authentication.AuthenticationManager.LoggedUser.Id);

            List<AppointmentIndexViewModel> model = new List<AppointmentIndexViewModel>();
            foreach (var appointment in appointments)
            {
                AppointmentIndexViewModel viewModel = new AppointmentIndexViewModel();

                Mapper.Map(appointment, viewModel);
                model.Add(viewModel);
            }

            return Json(new { data = model }, JsonRequestBehavior.AllowGet);
        }
        [IsLoggedUser]
        public override ActionResult Details(int id)
        {

            ViewModels.Appointment.AppoitmentEditViewModel model = new AppoitmentEditViewModel();
            Appointment appointment = service.Get(id);
            if (appointment == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (appointment.UserId != Authentication.AuthenticationManager.LoggedUser.Id)
            {
                return RedirectToAction("Index", "Home");
            }
            model.Id = appointment.Id;
            model.Username = appointment.User.Name;
            model.StartDateTime = appointment.StartDateTime.ToString();
            model.EndDateTime = appointment.EndDateTime.ToString();
            model.Activities = new List<ViewModels.CheckBoxView.ListCheckBoxViewModel>();

            foreach (var item in appointment.Activities)
            {
                model.Activities.Add(new ViewModels.CheckBoxView.ListCheckBoxViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsChecked = true,
                });
            }

            foreach (var item in activityService.GetAll().Except(appointment.Activities))
            {
                model.Activities.Add(new ViewModels.CheckBoxView.ListCheckBoxViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsChecked = false,
                });
            }
            return View(model);
        }


        public override void OnBeforeInsert()
        {
            IEnumerable<Activity> activities = activityService.GetAll();
            List<ActivityViewModel> model = new List<ActivityViewModel>();
            AppointmentCreateViewModel Vmodel = new AppointmentCreateViewModel();

            foreach (var activity in activities)
            {
                ActivityViewModel viewModel = new ActivityViewModel
                {
                    Id = activity.Id,
                    Name = activity.Name,
                    Duration = activity.Duration,
                    Price = activity.Price
                };
                model.Add(viewModel);
                Vmodel.ListBoxActivities = model;

            }


        }
        [IsLoggedUser]
        public override ActionResult Create()
        {
            if (Authentication.AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                IEnumerable<Activity> activities = activityService.GetAll();
                List<ActivityViewModel> model = new List<ActivityViewModel>();
                AppointmentCreateViewModel Vmodel = new AppointmentCreateViewModel();

                foreach (var activity in activities)
                {
                    ActivityViewModel viewModel = new ActivityViewModel
                    {
                        Id = activity.Id,
                        Name = activity.Name,
                        Duration = activity.Duration,
                        Price = activity.Price
                    };
                    model.Add(viewModel);
                    Vmodel.ListBoxActivities = model;

                }
                return View(Vmodel);


            }
        }


        [ValidateAntiForgeryToken]
        public override ActionResult Create(AppointmentCreateViewModel Vmodel, Appointment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Appointment appointment = new Appointment();

            model.StartDateTime = Convert.ToDateTime(Vmodel.StartDateTime);

            model.UserId = Authentication.AuthenticationManager.LoggedUser.Id;
            List<Activity> ac = new List<Activity>();
            foreach (var item in Vmodel.ListBoxActivities)
            {
                if (item.IsChecked)
                {
                    ac.Add(activityService.Get(item.Id));
                }
            }
            model.Activities = ac;
            model.EndDateTime = model.StartDateTime.AddHours(ac.Sum(a => a.Duration));

            if (!service.Insert(model))
            {
                return View(Vmodel);
            }
            return RedirectToAction("Index");
        }

        [IsLoggedUser]
        public override ActionResult Edit(int id)
        {


            ViewModels.Appointment.AppoitmentEditViewModel model = new AppoitmentEditViewModel();
            Appointment appointment = service.Get(id);
            if (appointment == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (appointment.UserId != Authentication.AuthenticationManager.LoggedUser.Id)
            {
                return RedirectToAction("Index", "Home");
            }
            model.Id = appointment.Id;
            model.StartDateTime = appointment.StartDateTime.ToString();
            model.EndDateTime = appointment.EndDateTime.ToString();
            model.Activities = new List<ViewModels.CheckBoxView.ListCheckBoxViewModel>();

            foreach (var item in appointment.Activities)
            {
                model.Activities.Add(new ViewModels.CheckBoxView.ListCheckBoxViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsChecked = true,
                });
            }

            foreach (var item in activityService.GetAll().Except(appointment.Activities))
            {
                model.Activities.Add(new ViewModels.CheckBoxView.ListCheckBoxViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsChecked = false,
                });
            }

            return View(model);
        }



        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppoitmentEditViewModel Vmodel, Appointment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Appointment appointment = service.Get(model.Id);
            appointment.StartDateTime = Convert.ToDateTime(model.StartDateTime);
            appointment.EndDateTime = Convert.ToDateTime(model.EndDateTime);
            appointment.UserId = appointment.UserId;
            appointment.Activities.Clear();

            List<Activity> ac = new List<Activity>();
            foreach (var item in Vmodel.Activities)
            {
                if (item.IsChecked)
                {
                    ac.Add(activityService.Get(item.Id));
                }
            }
            appointment.Activities = ac;

            if (!service.Update(appointment))
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        [IsLoggedUser]
        public override ActionResult Delete(int id)
        {
            ViewModels.Appointment.AppoitmentEditViewModel model = new AppoitmentEditViewModel();

            Appointment appointment = service.Get(id);

            if (appointment == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (appointment.UserId != Authentication.AuthenticationManager.LoggedUser.Id)
            {
                return RedirectToAction("Index", "Home");
            }
            model.Id = appointment.Id;
            model.StartDateTime = appointment.StartDateTime.ToString();
            model.EndDateTime = appointment.EndDateTime.ToString();
            model.Activities = new List<ViewModels.CheckBoxView.ListCheckBoxViewModel>();

            foreach (var item in appointment.Activities)
            {
                model.Activities.Add(new ViewModels.CheckBoxView.ListCheckBoxViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsChecked = true,

                });
            }

            foreach (var item in activityService.GetAll().Except(appointment.Activities))
            {
                model.Activities.Add(new ViewModels.CheckBoxView.ListCheckBoxViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsChecked = false,

                });
            }
            return View(model);
        }



        [ValidateAntiForgeryToken]
        public override ActionResult DeleteConfirmed(int id)
        {
            Appointment ap = service.Get(id);
            if (!service.Delete(ap))
            {
                return View(ap);
            }

            return RedirectToAction("Index");
        }
        [IsLoggedUser]
        public ActionResult Calendar()
        {

            return View();
        }
        public ActionResult LoadCalendar()
        {
            IEnumerable<Appointment> appointments = Authentication.AuthenticationManager.LoggedUser.IsAdmin ?
               service.GetAll() :
               service.GetAll(ap => ap.UserId == Authentication.AuthenticationManager.LoggedUser.Id);
            List<AppointmentIndexViewModel> model = new List<AppointmentIndexViewModel>();
            var rows = new object();

            foreach (var appointment in appointments)
            {
                List<string> activityName = new List<string>();
                AppointmentIndexViewModel viewModel = new AppointmentIndexViewModel()
                {
                    Id = appointment.Id,
                    UserId = appointment.UserId,
                    UserName = appointment.User.Name,
                    StartDateTime = appointment.StartDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    EndDateTime = appointment.EndDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    ActivitiesNames = activityName,
                };
                foreach (var activity in appointment.Activities)
                {
                    activityName.Add(activity.Name);
                }
                model.Add(viewModel);
            }
            var AppointmentsList = from e in model
                                   select new
                                   {
                                       id = e.Id,
                                       title = e.ActivitiesNames,
                                       start = e.StartDateTime,
                                       end = e.EndDateTime,
                                       color = String.Format("#{0:X6}", e.UserId * 1000000),
                                       allDay = false
                                   };
            rows = AppointmentsList.ToArray();

            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetReservedHours()
        {
            var hours = service.GetAll().Select(s => new { s.StartDateTime, s.EndDateTime }).ToArray();

            string[][] arr = new string[hours.Length][];

            for (int i = 0; i < hours.Length; i++)
            {
                arr[i] = new string[] { hours[i].StartDateTime.ToString("yyyy-MM-dd HH:mm"),
                                        hours[i].EndDateTime.ToString("yyyy-MM-dd HH:mm") };
            }
            return Json(arr, JsonRequestBehavior.AllowGet);
        }

    }
}