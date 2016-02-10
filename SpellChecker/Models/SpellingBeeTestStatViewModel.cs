using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpellChecker.Models
{
    public class SpellingBeeTestStatViewModel
    {
        public int SpellingBeeTestId { get; set; }
        public string SpellingBeeTestName { get; set; }
        public int NumberOfTests { get; set; }
        public int AverageScore { get; set; }
    }
}