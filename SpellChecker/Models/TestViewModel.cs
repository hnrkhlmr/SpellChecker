
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpellChecker.Dal.DomainObjects;

namespace SpellChecker.Models
{
    public class TestViewModel
    {
        public int UserTestId { get; set; }
        public List<WordViewModel> Words { get; set; }
        public bool ShowSwedish { get; set; }
        public bool AudioOn { get; set; }
        public int TestRights { get; set; }
        public int TestWrongs { get; set; }
    }

    public class SpellingBeeSelectionViewModel
    {
        public SpellingBeeSelection SpellingBeeList { get; set; }
        [Display(Name="Show word")]
        public bool ShowSwedish { get; set; }
        public bool AudioOn { get; set; }
    }

    public class SpellingBeeSelection
    {
        [Display(Name = "Select Spelling Bee")]
        public int SelectedSpellingBee { get; set; }
        public IEnumerable<SelectListItem> SpellingBees { get; set; }
    }

    public class WordViewModel
    {
        public int WordId { get; set; }
        public string EnglishText { get; set; }
        public string SwedishText { get; set; }        
        public string Input { get; set; }
    }

    public class TestResultViewModel
    {
        [Display(Name="Test Right Percentage")]
        public int RightPercentage { get; set; }

    }
}