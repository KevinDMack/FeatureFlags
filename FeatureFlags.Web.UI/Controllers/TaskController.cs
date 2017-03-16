using FeatureFlags.Business;
using FeatureFlags.Web.Attributes;
using FeatureFlags.Web.Providers;
using FeatureFlags.Web.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyIoC;

namespace FeatureFlags.Web.UI.Controllers
{
    [FeatureFlag(Constants.FeatureFlags.TaskScreen)]
    public class TaskController : Controller
    {
        private readonly ITaskProvider _taskProvider;

        //For bootstrap mapping
        //public TaskController(ITaskProvider taskProvider)
        //{
        //    _taskProvider = taskProvider;
        //}
        
        //For internal mapping
        public TaskController()
        {
            if (FlagCheckProvider.Instance.IsPreview(Constants.FeatureFlags.TaskProvider))
            {
                _taskProvider = (ITaskProvider)TinyIoCContainer.Current.Resolve<ITaskv2Provider>();
            }
            else
            {
                _taskProvider = (ITaskProvider)TinyIoCContainer.Current.Resolve<ITaskv1Provider>();
            }
        }

        // GET: Task
        public ActionResult Index()
        {
            var model = _taskProvider.GetTaskModel();
            return View(model);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
