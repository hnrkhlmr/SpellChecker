using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace SpellChecker.Web.Dal
{
    public class XmlHelper
    {
        public static void WriteXML<T>(T data, string filename)
        {
            var path = ConfigurationManager.AppSettings["xmlStorage"];
            
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (var file = new System.IO.StreamWriter(Path.Combine(path, filename + ".xml")))
            {
                writer.Serialize(file, data);
                file.Close();
            }
        }

        public static T ReadXml<T>(string filename)
        {
            //var path = ConfigurationManager.AppSettings["xmlStorage"];

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (var file = new System.IO.StreamReader(filename))
            {
                return (T)reader.Deserialize(file);
            }
        }
    }
}