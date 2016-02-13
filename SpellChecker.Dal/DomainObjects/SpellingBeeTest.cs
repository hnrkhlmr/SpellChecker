using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpellChecker.Dal.DomainObjects
{
    /// <summary>
    /// Test setup with collection of words.
    /// Searchtags for convinient searching.
    /// </summary>
    public class SpellingBeeTest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpellingBeeTestId { get; set; }
        public string Name { get; set; }
        public int WordsPerTest { get; set; }
        public ICollection<Word> Words { get; set; }
        public ICollection<SearchTag> Tags { get; set; }
        public ICollection<UserTest> UserTests { get; set; }
    }
}
