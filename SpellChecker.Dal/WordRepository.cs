using SpellChecker.Dal.DataTransferObjects;
using SpellChecker.Dal.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Dal
{
    public class WordRepository : EntityRepository, IWordRepository
    {
        public WordRepository():base()
        { }
        public WordRepository(SpellCheckerContext context):base(context)
        { }

        public IEnumerable<SpellingBeeTest> GetSpellingBeeTests()
        {
            return _context.SpellingBeeTests.ToList();
        }

        public UserTest GetUserTestById(int userTestId)
        {   
            return _context.UserTests.Find(userTestId);
        }

        public int CreateUserTest(UserTest userTest)
        {
            _context.UserTests.Add(userTest);
            _context.SaveChanges();
            return userTest.UserTestId;
        }

        public void UpdateUserTestscore(int userTestId, int score)
        {
            var userTest =_context.UserTests.Find(userTestId);
            userTest.ScorePercentage = score;
            _context.Entry(userTest).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void CreateTestWord(TestWord testWord)
        {
            _context.TestWords.Add(testWord);
            _context.SaveChanges();
        }

        public int GetUserTestCountByUserId(int userId)
        {
            return _context.UserTests.Where(u => u.ApplicationUserId.Equals(userId)).ToList().Count;
        }

        public IEnumerable<SpellingBeeTestStatDto> GetSpellingBeeTestStats(int userId)
        {
            var queryable = _context.SpellingBeeTests
                           .Select(a => new SpellingBeeTestStatDto
                           {
                               SpellingBeeTestId = a.SpellingBeeTestId,
                               SpellingBeeTestName = a.Name,                              
                               NumberOfTests = a.UserTests.Where(u => u.ApplicationUserId.Equals(userId)).Count(),
                               AverageScore = a.UserTests.Any() ? a.UserTests.Where(u => u.ApplicationUserId.Equals(userId)).Average(u => u.ScorePercentage) : 0
                           });

            return queryable.ToList();
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
