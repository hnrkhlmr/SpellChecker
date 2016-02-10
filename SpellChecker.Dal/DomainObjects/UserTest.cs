using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpellChecker.Dal.DomainObjects
{
    public class UserTest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTestId { get; set; }
        public int SpellingBeeTestId { get; set; }
        public SpellingBeeTest SpellingBeeRef { get; set; }
        public DateTime TestDate { get; set; }
        public int ScorePercentage { get; set; }
        public ICollection<TestWord> TestWords { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
