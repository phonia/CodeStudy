using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXCProject.Services.DTOs
{
    public class BaseDTO
    {
        private static int seed = 0;

        public static string RenderID()
        {
            StringBuilder sb = new StringBuilder();
            DateTime date = DateTime.Now;
            string[] strs = date.ToString().Split('-', ':', ' ');
            int random = new Random(seed).Next(100, 999);
            seed++;

            foreach (var str in strs)
                sb.Append(str.Length < 2 ? str.PadLeft(2, '0') : str);
            sb.Append(random);

            return sb.ToString();
        }
    }
}
