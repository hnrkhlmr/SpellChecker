using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SpellChecker.Dal;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace SpellCheckerTests
{
    [TestClass]
    public class WordRepositoryTest
    {
        [TestMethod]
        public void GetAllWords()
        {
            using (var ctx = new SpellCheckerContext())
            {
                var repository = new WordRepository(ctx);
                var all = repository.All;
                Assert.IsTrue(all.ToList().Count.Equals(100));
            }
        }

        [TestMethod]
        public void GetOneWordById()
        {
            using (var ctx = new SpellCheckerContext())
            {
                var repository = new WordRepository(ctx);
                var firstWord = repository.Find(1);
                Assert.AreEqual("cheese", firstWord.EnglishText);
                Assert.AreEqual("ost", firstWord.SwedishText);
            }
        }
    }
}
