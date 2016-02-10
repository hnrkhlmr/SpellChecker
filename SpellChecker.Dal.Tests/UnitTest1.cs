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
    }
}
