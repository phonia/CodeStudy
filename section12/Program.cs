using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace section12
{
    class Program
    {
        static void Main(string[] args)
        {
            //XMLHelper.CreateFC();
            XMLHelper.ReadFC();
        }
    }

    public class XMLHelper
    {
        public static void CreateFC()
        {
            List<Person> list = new List<Person>() { 
                new Person{Name="hy",Age=26},
                new Person{Name="pl",Age=17}
            };
            XElement xElement = new XElement("Employees",
                list.Select(it => new XElement("Person",
                    new XAttribute("Name",it.Name),
                    new XAttribute("Age",it.Age)
                    )));
            xElement.Save(@"E:\Code\CodeStudy\section12\Person.xml");
        }

        public static void ReadFC()
        {
            XElement xElement = XElement.Load(@"E:\Code\CodeStudy\section12\Person.xml");
            var query = xElement.Elements().Select(it => new { Name = (String)it.Attribute("Name"), Age = (int)it.Attribute("Age") });
            foreach (var item in query)
            {
                Console.Write("Name:{0},Age:{1}\n", item.Name, item.Age);
            }
        }
    }

    public class Person
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
    }
}
