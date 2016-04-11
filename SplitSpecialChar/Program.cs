using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitSpecialChar
{
    class Program
    {
        /**
         * 将指定字符从输入的字符串中排除，或者是检校输入字符串是否符合特定格式
         * 练习正则表达式的写法以及如何处理转义字符
         * 注意字符与字符串的区别
         * **/
        static void Main(string[] args)
        {
            string source = "sdfdsf*sdfsdfsd";
            char[] sourceChars = source.ToCharArray();
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            foreach (var node in sourceChars)
            {
                if (node.Equals('*')) continue;
                else sb.Append(node);
            }
            Console.Write(sb.ToString());
            Console.WriteLine();
        }
    }
}
