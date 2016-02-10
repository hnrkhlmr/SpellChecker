using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SpellChecker.Web.Dal
{
    public class Test
    {
        private readonly string fileName = ConfigurationManager.AppSettings["filenameWords"];

        public IEnumerable<Word> GetAllWords(string path)
        {
            return GetWords(path);
        }

        public IEnumerable<Word> GetLeastAppearedWords(int numberOfWords, string path)
        {
            if (numberOfWords.Equals(0))
            {
                numberOfWords = 10;
            }
            var words = GetWords(path);
            var leastAppeared = words.OrderBy(w => w.Appearances).Take(numberOfWords);
            return leastAppeared;
        }

        private IEnumerable<Word> GetWords(string path)
        {
            
            var wordsFromXml = XmlHelper.ReadXml<List<Word>>(path);
            return wordsFromXml;
        }

    }
}