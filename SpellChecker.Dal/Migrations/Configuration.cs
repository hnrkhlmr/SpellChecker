namespace SpellChecker.Dal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SpellChecker.Dal.DomainObjects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpellChecker.Dal.SpellCheckerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(SpellChecker.Dal.SpellCheckerContext context)
        {
            //SpellingBeeTest 1
            var spellingBeeTest = new SpellingBeeTest()
            {
                 Name = "First IESH Spelling Bee 4th grade 2016",
                 Tags = new List<SearchTag> { new SearchTag { Text = "weekdays" }, new SearchTag { Text= "months"} },
                 Words = new List<SpellChecker.Dal.DomainObjects.Word> {
                    #region start words
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "cheese", SwedishText = "ost" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "cauliflower", SwedishText = "blomk�l" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "mushrooms", SwedishText = "champinjon" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "meat", SwedishText = "k�tt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "cucumber", SwedishText = "gurka" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "garlic", SwedishText = "vitl�k" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "pineapple", SwedishText = "ananas" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "peas", SwedishText = "�rtor" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "cabbage", SwedishText = "k�l" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "potatoes", SwedishText = "potatis" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "grapes", SwedishText = "vindruvor" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "beans", SwedishText = "b�nor" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "orange", SwedishText = "apelsin" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "chicken", SwedishText = "kyckling" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "peach", SwedishText = "persika" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "bread", SwedishText = "br�d" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "fish", SwedishText = "fisk" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "eggs", SwedishText = "�gg" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "pumpkin", SwedishText = "pumpa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "butter", SwedishText = "sm�r" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "fresh", SwedishText = "f�rsk" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "raw", SwedishText = "r�" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "ripe", SwedishText = "mogen" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "rotten", SwedishText = "rutten" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "creamy", SwedishText = "kr�mig" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "crunchy", SwedishText = "knaprig" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "salty", SwedishText = "salt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "savoury", SwedishText = "v�lsmakande" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sour", SwedishText = "sur" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "spicy", SwedishText = "kryddad" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sweet", SwedishText = "s�t" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "monday", SwedishText = "m�ndag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "tuesday", SwedishText = "tisdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "wednesday", SwedishText = "onsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "thursday", SwedishText = "torsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "friday", SwedishText = "fredag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "saturday", SwedishText = "l�rdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sunday", SwedishText = "s�ndag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "be", SwedishText = "vara" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "have", SwedishText = "ha" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "do", SwedishText = "g�ra" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "say", SwedishText = "s�ga" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "go", SwedishText = "g�" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "get", SwedishText = "f�" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "make", SwedishText = "g�r" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "know", SwedishText = "veta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "think", SwedishText = "tror" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "take", SwedishText = "ta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "see", SwedishText = "se" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "come", SwedishText = "komma" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "want", SwedishText = "vill" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "use", SwedishText = "anv�nda" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "find", SwedishText = "hitta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "give", SwedishText = "ge" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "tell", SwedishText = "ber�tta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "work", SwedishText = "arbete" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "call", SwedishText = "ringa upp" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "try", SwedishText = "f�rs�ka" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "ask", SwedishText = "fr�ga" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "need", SwedishText = "beh�va" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "feel", SwedishText = "k�nna" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "become", SwedishText = "bli" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "leave", SwedishText = "l�mna" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "mean", SwedishText = "betyda" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "keep", SwedishText = "beh�lla" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "let", SwedishText = "l�ta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "begin", SwedishText = "b�rja" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "seem", SwedishText = "verka" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "help", SwedishText = "hj�lp" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "show", SwedishText = "visa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "hear", SwedishText = "h�ra" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "play", SwedishText = "spela" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "run", SwedishText = "springa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "move", SwedishText = "flytta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "live", SwedishText = "bo" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "believe", SwedishText = "tro" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "bring", SwedishText = "h�mta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "happen", SwedishText = "h�nda" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "write", SwedishText = "skriva" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sit", SwedishText = "sitta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "stand", SwedishText = "st�" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "lose", SwedishText = "f�rlora" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "pay", SwedishText = "betala" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "meet", SwedishText = "tr�ffa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "include", SwedishText = "inneh�lla" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "continue", SwedishText = "forts�tta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "set", SwedishText = "st�lla" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "learn", SwedishText = "l�ra" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "january", SwedishText = "januari" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "february", SwedishText = "februari" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "march", SwedishText = "mars" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "april", SwedishText = "april" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "may", SwedishText = "maj" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "june", SwedishText = "juni" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "july", SwedishText = "juli" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "august", SwedishText = "augusti" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "september", SwedishText = "september" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "october", SwedishText = "oktober" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "november", SwedishText = "november" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "december", SwedishText = "december" },
                    #endregion
                }
            };
            context.SpellingBeeTests.AddOrUpdate(s => s.Name, spellingBeeTest);
            context.SaveChanges();

            //SpellingBeeTest Weekdays
            var spellingBeeTestWeekDays = new SpellingBeeTest()
            {
                Name = "Weekdays",
                Tags = new List<SearchTag> { new SearchTag { Text = "weekdays" } },
                Words = new List<SpellChecker.Dal.DomainObjects.Word>
                {
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "monday", SwedishText = "m�ndag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "tuesday", SwedishText = "tisdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "wednesday", SwedishText = "onsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "thursday", SwedishText = "torsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "friday", SwedishText = "fredag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "saturday", SwedishText = "l�rdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sunday", SwedishText = "s�ndag" }
                }
            };
            context.SpellingBeeTests.AddOrUpdate(s => s.Name, spellingBeeTestWeekDays);
            context.SaveChanges();

            //SpellingBeeTest Months
            var spellingBeeTestMonths = new SpellingBeeTest()
            {
                Name = "Months",
                Tags = new List<SearchTag> { new SearchTag { Text = "months" } },
                Words = new List<SpellChecker.Dal.DomainObjects.Word>
                {
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "january", SwedishText = "januari" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "february", SwedishText = "februari" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "march", SwedishText = "mars" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "april", SwedishText = "april" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "may", SwedishText = "maj" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "june", SwedishText = "juni" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "july", SwedishText = "juli" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "august", SwedishText = "augusti" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "september", SwedishText = "september" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "october", SwedishText = "oktober" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "november", SwedishText = "november" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "december", SwedishText = "december" },
                    
                }
            };
            context.SpellingBeeTests.AddOrUpdate(s => s.Name, spellingBeeTestMonths);
            context.SaveChanges();

            //SpellingBeeTest Months
            var spellingBeeTestWeeklyWordsWeek6 = new SpellingBeeTest()
            {
                Name = "Veckans ord v6 2016",
                Tags = new List<SearchTag> { new SearchTag { Text = "week6" } },
                Words = new List<SpellChecker.Dal.DomainObjects.Word>
                {
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "gl�mde", SwedishText = "gl�mde" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "rymde", SwedishText = "rymde" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "t�mt", SwedishText = "t�mt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "skr�mt", SwedishText = "skr�mt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "svamla", SwedishText = "svamla" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "fastkl�mt", SwedishText = "fastkl�mt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "husnumret", SwedishText = "husnumret" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "v�lkomna", SwedishText = "v�lkomna" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "hamrar", SwedishText = "hamrar" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "slumrar", SwedishText = "slumrar" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "best�mt", SwedishText = "best�mt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "ber�md", SwedishText = "ber�md" },
                    
                }
            };
            context.SpellingBeeTests.AddOrUpdate(s => s.Name, spellingBeeTestWeeklyWordsWeek6);
            context.SaveChanges();
            #region old stuff, good to keep
            ////Orden            
            //var path = @"C:\Users\heho\documents\visual studio 2013\Projects\SpellChecker\SpellChecker\Data";
            //var fileWordName = "words.xml";
            //var wordsFromXml = XmlHelper.ReadXml<List<SpellChecker.Dal.Migrations.Word>>(Path.Combine(path, fileWordName));
                
            //foreach (var wordXml in wordsFromXml)
            //{
            //    wordXml.WordId = 0;
            //    SpellChecker.Dal.DomainObjects.Word word = new SpellChecker.Dal.DomainObjects.Word();
            //    word.EnglishText = wordXml.EnglishText;
            //    word.SwedishText = wordXml.SwedishText;
            //    word.SpellingBeeTestId = spellingBeeTest.SpellingBeeTestId;
            //    context.Words.AddOrUpdate(w => w.SwedishText, word);
            //}
            //context.SaveChanges();
            #endregion

            
        }

        
    }
    //public class Word
    //{
    //    public int WordId { get; set; }
    //    public string EnglishText { get; set; }
    //    public string SwedishText { get; set; }
    //    public int SpellingBeeTestId { get; set; }
    //    //public SpellingBeeTest SpellingBeeTestRef { get; set; }
    //}

    //public class XmlHelper
    //{
    //    public static void WriteXML<T>(T data, string filename)
    //    {
    //        var path = @"C:\Users\heho\documents\visual studio 2013\Projects\SpellChecker\SpellChecker\Data"; //ConfigurationManager.AppSettings["xmlStorage"];

    //        System.Xml.Serialization.XmlSerializer writer =
    //            new System.Xml.Serialization.XmlSerializer(typeof(T));

    //        using (var file = new System.IO.StreamWriter(Path.Combine(path, filename + ".xml")))
    //        {
    //            writer.Serialize(file, data);
    //            file.Close();
    //        }
    //    }

    //    public static T ReadXml<T>(string filename)
    //    {
    //        //var path = ConfigurationManager.AppSettings["xmlStorage"];

    //        System.Xml.Serialization.XmlSerializer reader =
    //            new System.Xml.Serialization.XmlSerializer(typeof(T));

    //        using (var file = new System.IO.StreamReader(filename))
    //        {
    //            return (T)reader.Deserialize(file);
    //        }
    //    }
    //}
}
