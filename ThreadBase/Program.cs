using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace ThreadBase
{
    /**
     *  多线程基础：
     *      
     * 
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(System.DateTime.Now.ToLongTimeString()+" "+System.DateTime.Now.Millisecond.ToString() + "\n");
            for (int i = 0; i < 100; i++) TestParall();
            Console.WriteLine(System.DateTime.Now.ToLongTimeString() + " " + System.DateTime.Now.Millisecond.ToString() + "\n");
            Console.WriteLine(System.DateTime.Now.ToLongTimeString() + " " + System.DateTime.Now.Millisecond.ToString() + "\n");
            Parallel.For(0,100,i=>TestParall());
            Console.WriteLine(System.DateTime.Now.ToLongTimeString() + " " + System.DateTime.Now.Millisecond.ToString() + "\n");

        }

        static void TestParall()
        {
            int i = 0;
            while (i < 100000000)
            {
                i++;
            }
        }
    }
}
