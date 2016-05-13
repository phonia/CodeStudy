using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityStudy
{
    public class ObjectInheritFromInjectPropertyInterface:IInjectPropertyInterface
    {
        public String UserName { get; set; }
        public String UserPwd { get; set; }
    }
}
