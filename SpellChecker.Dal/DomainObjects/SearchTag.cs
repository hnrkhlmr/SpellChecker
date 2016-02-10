using System.ComponentModel.DataAnnotations.Schema;

namespace SpellChecker.Dal.DomainObjects
{
    public class SearchTag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SearchTagId { get; set; }
        public int SpellingBeeTestId { get; set; }
        public SpellingBeeTest SpellingBeeTestRef { get; set; }
        public string Text { get; set; }
    }
}
