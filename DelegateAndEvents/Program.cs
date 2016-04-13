using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Delegation delegation = new Delegation();
            Action a1 = () => Console.Write("Hi!\n");
            Action a2 = () => Console.Write("Hi again!\n");
            delegation.Work += a1;
            delegation.Work += a2;
            delegation.Do();
        }
    }


    public class Delegation
    {
        public Action Work { get; set; }

        public void Do()
        {
            if (Work != null) Work();
        }
    }
}
