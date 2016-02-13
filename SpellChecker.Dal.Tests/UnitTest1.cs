using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellChecker.Dal;
using SpellChecker.Dal.DataTransferObjects;
using SpellChecker.Dal.DomainObjects;
using System.Linq;

namespace SpellChecker.Dal.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var ctx = new SpellCheckerContext())
            {
                var repository = new WordRepository(ctx);
                var stats = repository.GetSpellingBeeTestStats(2);

                Assert.IsTrue(stats.Any());
            }
        }

        [TestMethod]
        public void GetWordsForTestTest()
        {
            using (var ctx = new SpellCheckerContext())
            {
                var repository = new WordRepository();
                var testWordDtos = repository.GetWordsForTest(1);

                Assert.AreEqual(10, testWordDtos.Count());
            }
        }

        [TestMethod]
        public void GetAverageScoreTest()
        {
            using (var ctx = new SpellCheckerContext())
            {
                var repository = new WordRepository();
                var testStat = repository.GetSpellingBeeTestStats(2).ToList();

                Assert.AreEqual(4, testStat.Count());
                Assert.AreEqual(6, testStat[1].NumberOfTests);
                Assert.AreEqual(33, decimal.Round(Convert.ToDecimal(testStat[1].AverageScore)));
            }
            /*
             * 
             * SpellingBeeTestId	Name	WordsPerTest	TestDone	AverageScore
                1	First IESH Spelling Bee 4th grade 2016	10	10	39
                2	Weekdays	7	6	33
                3	Months	12	0	NULL
                4	Veckans ord v6 2016	12	1	58
             * */
        }
    }
}
