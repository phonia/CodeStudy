using System;
using System.Collections.Generic;
using System.Text;

namespace Section3
{
    class Program
    {
        private static String s;
        static void Main(string[] args)
        {
            //FX<String>.T = "sfd";
            //FX<int>.T = 1;
            //Console.Write(FX<String>.T);
            int m = 0;
            Action<int> fc = it => m++;
            Action<int> sc = it => m++;
            Action<int> tc = it => m++;
            fc(m);
            sc(m);
            tc(m);
            Console.Write(m);
        }
    }

    public class FX<TS>
    {
        public static TS T { get; set; }
    }
}
