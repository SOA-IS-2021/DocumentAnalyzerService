using edu.stanford.nlp.ie.crf;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace NLP_Demo.Models
{
    public class NLPlib
    {
        public List<string> GetEmployee(string document, List<string> entry,CRFClassifier classifier)
        

        
        {

            //var classifiersDirecrory = Environment.CurrentDirectory + @"\stanford-ner-2016-10-31\classifiers";

            // Loading 7 class classifier model
            //var classifier = CRFClassifier.getClassifierNoExceptions(Path.Combine(classifiersDirecrory, "english.muc.7class.distsim.crf.ser.gz"));

            //Load the document that needs to be recognized with Named Entities contained in it.
            //var document = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "demo.txt"));

            //Use the classifyToString method with the document loaded as the 1st argument and 
            //give "xml" as 2nd argument for output format with preserveSpacing set to true as 3rd argument
            string xmlContent = classifier.classifyToString(document, "xml", true);

            //Wrap the reslutant xmlContent with parent and WiCollection tag.
            //This is just for XML Deserialization that eases to perform LINQ operations
            var xml = $"<WiCollection><parent>{xmlContent}</parent></WiCollection>";

            //POCO to hold DeSerialized XML
            WiCollection wiCollection = null;

            //Deserialize XML
            XmlSerializer serializer = new XmlSerializer(typeof(WiCollection));
            using (TextReader reader = new StringReader(xml))
            {
                wiCollection = (WiCollection) serializer.Deserialize(reader);
            }

            //Iterate and print standard Entity types
            var entities = Enum.GetValues(typeof(Entity)).Cast<Entity>();



            var names = new List<string>();
            //var entry = new List<string>();
            var result = new List<string>();
            var persons = new List<string>();


            foreach (var entity in entities)
            {
                var tags = wiCollection.Wi.Where(x =>
                    x.Entity.ToLowerInvariant() == entity.ToString().ToLowerInvariant());
                names.Add(string.Join(",", tags.Select(w => w.Text)));

            }

            foreach (var i in names)
            {
                string[] subs = i.Split(',');

                foreach (var j in subs)
                {
                    result.Add(j);
                }
            }

            foreach (var i in result)
            {
                foreach (var j in entry)
                {
                    if (i == j)
                    {
                        persons.Add(i);
                    }
                }
            }

            var encontrados = ((from s in persons select s).Distinct()).ToList();


            return encontrados;
        }

    }
}