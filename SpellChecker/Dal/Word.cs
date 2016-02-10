using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpellChecker.Web.Dal
{
    public class Word
    {
        public int WordId { get; set; }
        public string EnglishText { get; set; }
        public string SwedishText { get; set; }
        public int Rights { get; set; }
        public int Wrongs { get; set; }
        public decimal Appearances { get { return Rights + Wrongs; } }
    }
}