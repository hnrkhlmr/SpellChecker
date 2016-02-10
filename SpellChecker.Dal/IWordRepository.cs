using SpellChecker.Dal.DataTransferObjects;
using SpellChecker.Dal.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Dal
{
    public interface IWordRepository:IEntityRepository<Word>
    {
        IEnumerable<SpellingBeeTest> GetSpellingBeeTests();
        int CreateUserTest(UserTest userTest);
        void CreateTestWord(TestWord testWord);
        IEnumerable<SpellingBeeTestStatDto> GetSpellingBeeTestStats(int userId);
        UserTest GetUserTestById(int userTestId);
        void UpdateUserTestscore(int userTestId, int score);
        IEnumerable<ApplicationUser> GetUsers();
        int GetUserTestCountByUserId(int userId);
    }
}
