using System;
using API;
using System.Xml;
namespace APItest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebTools test = new WebTools();

            XmlDocument xmlString = new XmlDocument();
            Console.Write("What is the zipcode you would like to lookup? ");
            string input = Console.ReadLine();
            string output = test.CityStateLookupRequest(input);
            Console.WriteLine();
            xmlString.LoadXml(output);
            XmlNode root = xmlString.FirstChild;
            XmlNode next = root.NextSibling;
            XmlNode layer1 = next.FirstChild;
            if (layer1.HasChildNodes)
            {
                for (int i = 0; i < layer1.ChildNodes.Count; i++)
                {
                    Console.WriteLine(layer1.ChildNodes[i].InnerText);
                }
            }
            XmlNode root2 = root.FirstChild;

        }
    }
}
