using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TestingSystem.Testing;

namespace TestingSystem.Utils
{
    public class XmlToTestConverter
    {
        public static Test XmlToTest(XmlDocument doc)
        {
            XDocument d;
            using (var nodeReader = new XmlNodeReader(doc))
            {
                nodeReader.MoveToContent();
                d = XDocument.Load(nodeReader);
            }

            var root = d.Root;
            Test test = new Test();
            foreach (var item in root.Elements("Question"))
            {
                string text = item.Attribute("Text").Value;
                int countOfVariants = item.Elements("Var").Count();
                string[] variants = new string[countOfVariants];
                int index = 0;
                foreach (var v in item.Elements("Var"))
                {
                    variants[index] = v.Value;
                    index++;
                }
                string correctAnswer = item.Element("Correct").Value;

                Question question = new Question(variants, variants.ToList().IndexOf(correctAnswer), text);
                test.AddQuestion(question);
            }
            return test;
        }
    }
}
