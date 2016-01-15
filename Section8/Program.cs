using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Section8
{
    class Program
    {
        static void Main(string[] args)
        {
            var humans = new List<Person>() { 
                new Person(){Name="sfsd",Age=1}
            };
        }
    }

    public class Person
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
    }
}
