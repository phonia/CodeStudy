using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadLock
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            User.Balance=100;
            Thread[] th = new Thread[20];
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    th[i] = new Thread(new ThreadStart(user.Save));
                }
                else
                {
                    th[i] = new Thread(new ThreadStart(user.Withdraw));
                }
            }
            for (int i = 0; i < 10; i++)
            {
                th[i].Start();
            }
        }
    }

    public class User
    {
        private static object _lockObject = new object();

        public static int Balance { get; set; }

        public void Save()
        {
            int money = 10;
            lock (_lockObject)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("------");
                Console.WriteLine(Balance);
                Balance = Balance + money;
                System.Threading.Thread.Sleep(10000);
                Console.WriteLine(Balance);
                Console.WriteLine("------");
            }
        }

        public void Withdraw()
        {
            int money = 10;
            //lock (_lockObject)
            //{
                if (Balance > money)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("------");
                    Console.WriteLine(Balance);
                    Balance = Balance - money;
                    Console.WriteLine(Balance);
                    Console.WriteLine("------");
                }
            //}
        }
    }
}
