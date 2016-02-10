using AutoMapper;
using log4net;
using SpellChecker.Dal;
using SpellChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpellChecker.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SpellController));
        private IWordRepository _repository;

        public AdminController()
        {
            _repository = new WordRepository();
        }

        public AdminController(IWordRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var userStatViewModelList = new List<UserStatViewModel>();
            var users = _repository.GetUsers();
            
            foreach (var user in users)
            {
                var testCountPerUser = _repository.GetUserTestCountByUserId(user.Id);
                var userStat = new UserStatViewModel
                {                    
                    Email = user.Email,
                    UserId = user.Id,
                    UserName = user.UserName,                    
                    NumberOfTests = testCountPerUser                    
                };
                userStatViewModelList.Add(userStat);
            }
            
            return View(userStatViewModelList);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var tester = _repository.GetSpellingBeeTestStats(id);
            var model = Mapper.Map<IEnumerable<SpellingBeeTestStatViewModel>>(tester);
            return View(model);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
