using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace XmlToJsonConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var xml = System.IO.File.ReadAllText(@"..\data\Catalog.xml");
            
            // To convert an XML node contained in string xml into a JSON string   
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc, Formatting.Indented);

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.WriteAllText(Path.Combine(docPath, "Catalog.json"), jsonText);

            Console.WriteLine(jsonText);
            Console.WriteLine("Processing complete");
            Console.ReadKey();
        }
    }
}