using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Dal.DataTransferObjects
{
    public class SpellingBeeTestStatDto
    {
        public int SpellingBeeTestId { get; set; }
        public string SpellingBeeTestName { get; set; }
        public int NumberOfTests { get; set; }
        public double AverageScore { get; set; }
    }
}
