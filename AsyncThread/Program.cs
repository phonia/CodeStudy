using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AsyncThread
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tc = new TcpClient();
            tc.BeginConnect("192.168.10.10", 5555, new AsyncCallback(End), tc);
            while (true)
            {
                Thread.Sleep(3000);
                Console.Write("s:\n");
            }
        }

         static void End(IAsyncResult ar)
        {
            TcpClient tc = (TcpClient)ar.AsyncState;
            Console.Write("beforeEnd");
            tc.EndConnect(ar);
            Console.Write("End");
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public static List<Product> get()
        {
            List<Product> list = new List<Product>();
            list.Add(new Product(name: "", price: 0));
            return list;
        }
    }
}
