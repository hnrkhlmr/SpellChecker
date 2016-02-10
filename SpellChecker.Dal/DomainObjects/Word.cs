using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Dal.DomainObjects
{
    public class Word
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WordId { get; set; }
        public string EnglishText { get; set; }
        public string SwedishText { get; set; }
        public int SpellingBeeTestId { get; set; }
        public SpellingBeeTest SpellingBeeTestRef { get; set; }
    }   
    
}
