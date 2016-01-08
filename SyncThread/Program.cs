using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SyncThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("PrintBefore");
            Thread th = new Thread(new ThreadStart(Print));
            th.Start();
            Console.Write("Printafter");
        }

        static void Print()
        {
            Console.Write("Print");
            Thread.Sleep(30000);
            Console.Write("Print");
        }
    }
}
