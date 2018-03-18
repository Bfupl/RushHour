using AutoMapper;

using RushHour.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RushHour.Web.ActionFilters;
using RushHour.BaseService.Domain;
using RushHour.Common.Interfaces;

namespace RushHour.Web.Controllers
{
    public abstract class CrudController<TModel, TViewModel>
        : Controller where TModel : BaseModel, new()
                     where TViewModel : BaseViewModel, new()
    {
        // GET: Crud

        protected IService<TModel> service;
        protected IService<TModel> secondService;

        public CrudController(IService<TModel> service)
        {
            this.service = service;
            //this.service = new DataService<TModel>(new Data.Repositories.UnitOfWork());

        }
        public CrudController(IService<TModel> service, IService<TModel> secondService)
        {
            this.service = service;
            this.secondService = secondService;

            //this.service = new DataService<TModel>(new Data.Repositories.UnitOfWork());

        }


        [IsLoggedUser]
        [HttpGet]
        public virtual ActionResult Index()
        {

            return View();

        }
        [IsLoggedUser]
        [HttpGet]
        public virtual ActionResult Create()
        {


            // OnBeforeInsert();
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TViewModel Vmodel, TModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(Vmodel);
            }
            Mapper.Map(Vmodel, model);
            if (!service.Insert(model))
            {
                return View();
            }
            // OnAfterInsert(model,Vmodel);

            return RedirectToAction("Index");
        }
        [IsLoggedUser]
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {

            TViewModel vModel = new TViewModel();
            TModel model = service.Get(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapper.Map(model, vModel);
            return View(vModel);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TViewModel Vmodel, TModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(Vmodel);
            }

            if (!service.Update(model))
            {
                return View();
            }

            return RedirectToAction("Index");
        }
        [IsLoggedUser]
        public virtual ActionResult Details(int id)
        {

            TViewModel vModel = new TViewModel();
            TModel model = service.Get(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapper.Map(model, vModel);
            return View(vModel);

        }
        [IsLoggedUser]
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {

            TViewModel vModel = new TViewModel();
            TModel model = service.Get(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapper.Map(model, vModel);
            return View(vModel);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            TModel model = service.Get(id);
            if (!service.Delete(model))
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public virtual ActionResult LoadData()
        {

            IEnumerable<TModel> models = service.GetAll();
            List<TViewModel> model = new List<TViewModel>();
            foreach (var item in models)
            {
                Mapper.Map(models, model);
            }

            return Json(new { data = model }, JsonRequestBehavior.AllowGet);

        }

        public virtual void OnBeforeInsert() { }
        //public virtual  TViewModel OnBeforeInsert(TModel model, TViewModel vModel)
        //{

        //    IEnumerable<TModel> models = service.GetAll();
        //    List<TViewModel> viewModels = new List<TViewModel>();


        //    foreach (var item in models)
        //    {
        //        TViewModel viewModel = new TViewModel { };


        //        viewModels.Add(viewModel);


        //    }
        //    return vModel;
        //}

    }
}