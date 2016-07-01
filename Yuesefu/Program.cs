using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuesefu
{
    class Program
    {
        static void Main(string[] args)
        {
            Yuesefu(10, 1, 3);
        }

        static void Yuesefu(int count, int start, int m)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                list.Add(i);
            }

            if (start < 1) return;
            start = start - 1;
            if (m < 1) return;
            m = m - 1;
            while (list.Count > 0)
            {
                start = (start+m) % list.Count;
                Console.WriteLine(list[start]);
                list.RemoveAt(start);
            }
        }
    }
}
