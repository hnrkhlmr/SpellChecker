using System.ComponentModel.DataAnnotations.Schema;

namespace SpellChecker.Dal.DomainObjects
{
    public class TestWord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestWordId { get; set; }
        public int WordId { get; set; }
        public int UserTestId { get; set; }
        public UserTest UserTestRef { get; set; }
        public bool Correct { get; set; }
    }
}
