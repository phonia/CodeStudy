using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Section2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 委托操作
             * *
             */
            //Delegation dl = new Delegation();
            //dl.Exec();


            /*
             * 类型安全
             *
             * **/
            //强集合类型
            //String[] s = new string[5];
            //object[] o = s;
            //s[0] = new Delegation();

            //弱集合类型
            //ArrayList al = new ArrayList();
            //al.Add("sdf");
            //al.Add(new Delegation());
            //foreach (object o in al)
            //{
            //    ((Delegation)o).Exec();
            //}

            /*
             * 可空值类型
             * 此处（!(i>0))≠(i<=0)
             * **/
            //int? i = null;
            //if (!(i > 0))
            //{
            //    Console.Write("true!");
            //}
        }
    }
}
