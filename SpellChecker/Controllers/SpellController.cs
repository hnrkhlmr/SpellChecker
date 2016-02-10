using SpellChecker.Dal;
using SpellChecker.Dal.DomainObjects;
using SpellChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using log4net;

namespace SpellChecker.Controllers
{
    [Authorize]
    public class SpellController : Controller
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILog log = LogManager.GetLogger(typeof(SpellController));
        private ApplicationUserManager _manager;
        private IWordRepository _repository;
        public SpellController()
        {                        
            _repository = new WordRepository();
        }
        public SpellController(IWordRepository repository, ApplicationUserManager manager)
        {
            _manager = manager;
            _repository = repository;
        }

        public ApplicationUserManager SpellUserManager 
        { 
            get
            {
                if (_manager!=null)
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
        // GET: Spell
        public ActionResult Index()
        {
            try
            {
                log.Debug("Nuskavise.");
                var bees = _repository.GetSpellingBeeTests();
                var typeList = new List<SelectListItem>();

                foreach (var test in bees)
                {
                    typeList.Add(new SelectListItem
                        {
                            Text = test.Name,
                            Value = test.SpellingBeeTestId.ToString()
                        });
                }
                var types = new SelectList(typeList, "Value", "Text");
                var selection = new SpellingBeeSelection()
                {
                    SpellingBees = types
                };

                var model = new SpellingBeeSelectionViewModel() { SpellingBeeList = selection, AudioOn = true, ShowSwedish = true };

                return View(model);
            }
            catch (Exception e)
            {
                log.Error("Något gick fel.", e);
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult SpellTest(FormCollection collection, SpellingBeeSelectionViewModel spellingBeeModel) //int numOfWordsId, bool topWrongs)
        {
            try
            {
                var appUser = SpellUserManager.FindByName(User.Identity.Name);

                if (ModelState.IsValid && spellingBeeModel != null)
                {
                    var selectedBeeId = spellingBeeModel.SpellingBeeList.SelectedSpellingBee;
                    var words = _repository.All.Where(w => w.SpellingBeeTestId.Equals(selectedBeeId)).ToList();
                    //skapa testwords
                    var testWords = words.Select(w =>
                        new TestWord
                        {
                            WordId = w.WordId
                        }).ToList();
                    //skapa usertest
                    var userTest = new UserTest()
                    {
                        ApplicationUserId = appUser.Id,
                        SpellingBeeTestId = selectedBeeId,
                        TestDate = DateTime.Now,
                        TestWords = testWords
                    };
                    var userTestId = _repository.CreateUserTest(userTest);
                    //spara usertest
                    var model = new TestViewModel();
                    model.UserTestId = userTestId;
                    model.ShowSwedish = spellingBeeModel.ShowSwedish;
                    var audioOn = spellingBeeModel.AudioOn;
                    model.Words = words.Select(m =>
                        new WordViewModel
                        {
                            EnglishText = m.EnglishText,
                            SwedishText = m.SwedishText,
                            WordId = m.WordId
                        }).ToList();
                    return View(model);
                }
            }
            catch (Exception e)
            {
                log.Error("Något gick fel.", e);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SpellTest(FormCollection collection, TestViewModel model)
        {
            //TODO: Flytta skapandet av testet hit. Då slipper man tomma test om anv avbryter testet utan att spara.
            // TODO: hantera browser-navigering.
            foreach (var word in model.Words)
            {
                var testWord = new TestWord();
                testWord.UserTestId = model.UserTestId;
                testWord.WordId = word.WordId;

                var right = string.IsNullOrEmpty(word.Input) ? false : word.EnglishText.Equals(word.Input.ToLower());
                if (right)
                {
                    testWord.Correct = true;
                }

                _repository.CreateTestWord(testWord);
            }
            var percentage = Convert.ToInt32(Decimal.Round((Convert.ToDecimal(model.TestRights) / Convert.ToDecimal(model.Words.Count)), 2) * 100);
            var testResultViewModel = new TestResultViewModel()
            {
                RightPercentage = percentage
            };
            //Uppdatera UserTest med procenten
            _repository.UpdateUserTestscore(model.UserTestId, percentage);
            
            return RedirectToAction("SpellTestResult", testResultViewModel);
        }

        public ActionResult SpellTestResult(TestResultViewModel model)
        {
            return View(model);
        }
        // GET: Spell/Details/5
        public ActionResult Details(int id)
        {
            //skicka lista direkt instantioera
            return View();
        }

        // GET: Spell/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spell/Create
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

        // GET: Spell/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Spell/Edit/5
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

        // GET: Spell/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Spell/Delete/5
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
