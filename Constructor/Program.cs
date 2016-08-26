using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User() { Age = 10 };
            Console.WriteLine(user.Age);
            Console.WriteLine(user.Note);
            CLog log = new CLog();
            log.PrintO();
            log.PrintT();
        }
    }

    public class User
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public String Note { get; set; }

        public User()
        {
            Note = "NoThing!";
        }
    }



    public interface ILog
    {
         void PrintO();
         void PrintT();
    }

    public partial class CLog : ILog
    {
        public void PrintO()
        {
            Console.WriteLine("O");
        }
    }

    public partial class CLog : ILog
    {
        public void PrintT()
        {
            Console.WriteLine("T");
        }
    }
}
