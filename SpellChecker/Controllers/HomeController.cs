using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpellChecker.Dal;

namespace SpellChecker.Controllers
{
    public class HomeController : Controller
    {
        private IWordRepository _repository;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Practice your spelling the spelling bee way.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}