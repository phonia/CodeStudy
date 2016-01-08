using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Section2
{
    /// <summary>
    /// 委托的调用以及委托的操作：
    /// </summary>
    public class Delegation
    {
        public Action<String> Print { get; set; }

        public Delegation()
        { }

        public void Exec()
        {
            Print += it => Console.Write("1"+it);
            Print += it => Console.Write("2" + it);
            Print += ddd;
            //Print -= ddd;
            if (this.Print != null)
                Print("hello world\n");
        }

        public void ddd(string input)
        {
            Console.Write("3"+input);
        }
    }
}
