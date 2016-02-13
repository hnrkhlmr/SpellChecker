using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Dal.DataTransferObjects
{
    public class TestWordDto
    {
        public int WordId { get; set; }
        public string EnglishText { get; set; }
        public string SwedishText { get; set; }
        public bool Correct { get; set; }
        public double RandomSelector { get; set; }
    }
}
