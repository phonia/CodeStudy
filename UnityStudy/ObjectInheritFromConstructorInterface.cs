using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityStudy
{
    public class ObjectInheritFromConstructorInterface:IInjectConstructInterface
    {
        public String UserName { get; set; }
        public String UserPwd { get; set; }

        public ObjectInheritFromConstructorInterface(String userName, String userPwd)
        {
            this.UserPwd = userPwd;
            this.UserName = userName;
        }
    }
}
