using System;
using System.Collections.Generic;
using System.Text;

namespace Section3
{
    class Program
    {
        static void Main(string[] args)
        {
            FX<String>.T = "sfd";
            FX<int>.T = 1;
            Console.Write(FX<String>.T);
        }
    }

    public class FX<TS>
    {
        public static TS T { get; set; }
    }
}
