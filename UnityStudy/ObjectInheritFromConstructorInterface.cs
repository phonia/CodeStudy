using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityStudy
{
    public class ObjectInheritFromConstructorInterface:IInjectConstructInterface
    {
        public String UserName { get; set; }
        public String userPwd { get; set; }

        public ObjectInheritFromConstructorInterface(String userName, String userPwd)
        { }
    }
}
