using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXCProject.Infrastructure.Domain
{
    public abstract class BaseEntity<TID> : IEntity
    {
        public virtual TID ID { get; set; }

        public string GetID()
        {
            StringBuilder sb = new StringBuilder();
            DateTime date = DateTime.Now;
            string[] strs = date.ToString().Split('-', ':', ' ');
            string millisecond = date.Millisecond.ToString();

            foreach (var str in strs)
            {
                sb.Append(str.Length < 2 ? str.PadLeft(2, '0') : str);
            }
            sb.Append(millisecond.Length < 3 ? millisecond.PadLeft(3, '0') : millisecond);

            return sb.ToString();
        }
    }
}
