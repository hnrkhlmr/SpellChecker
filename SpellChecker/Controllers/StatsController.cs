using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SpellChecker.Dal;
using AutoMapper;
using SpellChecker.Models;
using log4net;

namespace SpellChecker.Controllers
{
    [Authorize]
    public class StatsController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StatsController));

        private ApplicationUserManager _manager;
        private IWordRepository _repository;

        public StatsController()
        {
            _repository = new WordRepository();
        }

        public StatsController(IWordRepository repository, ApplicationUserManager manager)
        {
            _manager = manager;
            _repository = repository;
        }

        public ApplicationUserManager SpellUserManager
        {
            get
            {
                if (_manager != null)
                {
                    return _manager;
                }
                else
                {
                    _manager = HttpContext.GetOwinContext().Get<ApplicationUserManager>();
                    return _manager;
                }
            }
        }

        // GET: Stats
        public ActionResult Index()
        {
            try
            {
                var appUser = SpellUserManager.FindByName(User.Identity.Name);
                //Hämta tester för användaren och visa
                var tester = _repository.GetSpellingBeeTestStats(appUser.Id);
                var model = Mapper.Map<IEnumerable<SpellingBeeTestStatViewModel>>(tester);
                return View(model);
            }
            catch (Exception e)
            {
                log.Error("Något gick fel.", e);
            }
            return View();
        }

        // GET: Stats/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stats/Create
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

        // GET: Stats/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stats/Edit/5
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

        // GET: Stats/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stats/Delete/5
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
