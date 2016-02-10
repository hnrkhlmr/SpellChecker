using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SpellChecker.Dal;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using SpellChecker.Web.Dal;
using System.Text;

namespace SpellCheckerTests
{
    //[Ignore]
    [TestClass]
    public class DataTest
    {
        private readonly string fileName = ConfigurationManager.AppSettings["filenameWords"];

        [TestMethod]
        public void TestMethod1()
        {
            //var words = new List<Word>();
            //using (var sr = new StreamReader(@"c:\users\heho\documents\visual studio 2013\Projects\SpellChecker\SpellChecker\Words.txt"))
            //{
            //    var idCount = 0;
            //    while (!sr.EndOfStream)
            //    {
                    
            //        var line = sr.ReadLine();
            //        if (!string.IsNullOrEmpty(line.Trim()))
            //        {
            //            var tempWord = new Word();
            //            //tempWord.WordId = ++idCount;
            //            tempWord.EnglishText = line.Trim().ToLower();
            //            tempWord.SwedishText = line.Trim().ToLower();
            //            words.Add(tempWord);
            //        }
            //    }
            //}

            //Assert.IsTrue(words.Any());
            //XmlHelper.WriteXML<List<Word>>(words, fileName);
            //var wordsFromXml = XmlHelper.ReadXml<List<Word>>(fileName);
            //Assert.IsTrue(wordsFromXml.Any());
            //Assert.AreEqual<int>(words.Count, wordsFromXml.Count);
        }

        [Ignore]
        [TestMethod]
        public void UppdateraId()
        {
            //var fileWordName = "words";
            //var words = new List<Word>();
            //var wordsFromXml = XmlHelper.ReadXml<List<Word>>(fileWordName);
            //var idCount = 0;
            //foreach (var word in wordsFromXml)
            //{
            //    word.WordId = ++idCount;
            //    words.Add(word);
            //}
            //XmlHelper.WriteXML<List<Word>>(words, fileWordName);
        }

        //[Ignore]
        [TestMethod]
        public void LoadDatabaseFromXmlFile()
        {
            using (var ctx = new SpellCheckerContext())
            {
                var fileWordName = "words.xml";
                var words = new List<SpellChecker.Dal.DomainObjects.Word>();
                var wordsFromXml = XmlHelper.ReadXml<List<SpellChecker.Dal.DomainObjects.Word>>(fileWordName);
                Assert.IsTrue(wordsFromXml.Count.Equals(100));
                var repository = new WordRepository(ctx);
                foreach (var word in wordsFromXml)
                {
                    word.WordId = 0;
                    repository.InsertOrUpdate(word);
                }
                var all = repository.All;
                Assert.IsTrue(all.ToList().Count.Equals(100));
            }
        }

        [Ignore]
        [TestMethod]
        public void UpdateSwedishTextInDbFromXmlFile()
        {
            using (var ctx = new SpellCheckerContext())
            {
                var fileWordName = "words.xml";
                var words = new List<SpellChecker.Dal.DomainObjects.Word>();
                var wordsFromXml = XmlHelper.ReadXml<List<SpellChecker.Dal.DomainObjects.Word>>(fileWordName);
                var repository = new WordRepository(ctx);
                foreach (var word in wordsFromXml)
                {
                    var dbword = repository.Find(word.WordId);
                    dbword.SwedishText = word.SwedishText;
                    repository.InsertOrUpdate(dbword);
                }
                var all = repository.All;
                Assert.IsTrue(all.Where(w => w.SwedishText!=null).ToList().Count.Equals(100));
                Assert.IsTrue(all.ToList().Count.Equals(100));
            }
        }

        [TestMethod]
        public void CreateSeedData()
        {
            using (var ctx = new SpellCheckerContext())
            {
                var sb = new StringBuilder("Words = new List<SpellChecker.Dal.DomainObjects.Word>");
                sb.AppendLine("{");
                var repository = new WordRepository(ctx);
                var words = repository.All.Where(w => w.SpellingBeeTestId.Equals(1)).ToList();
                foreach (var word in words)
                {
                    sb.AppendLine(string.Format("new SpellChecker.Dal.DomainObjects.Word {{ EnglishText = \"{0}\", SwedishText = \"{1}\" }},", word.EnglishText, word.SwedishText));
                }
                sb.AppendLine("}");
                using (var sw = new StreamWriter(@"c:\xml\spellchecker\words.cs"))
                {
                    sw.Write(sb.ToString());
                }
            }
            
            /*
             * 
                Words = new List<SpellChecker.Dal.DomainObjects.Word>
                {
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "monday", SwedishText = "måndag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "tuesday", SwedishText = "tisdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "wednesday", SwedishText = "onsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "thursday", SwedishText = "torsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "friday", SwedishText = "fredag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "saturday", SwedishText = "lördag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sunday", SwedishText = "söndag" }
                }
             */
        }
    }
}
