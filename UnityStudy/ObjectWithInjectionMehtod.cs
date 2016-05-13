using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityStudy
{
    public class ObjectWithInjectionMehtod
    {
        public String UserName { get; set; }

        public void SetName(string userName)
        {
            this.UserName = userName;
        }
    }
}
