using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityStudy
{
    // Our various test objects
    public class ClassWithOneGenericParameter<T>
    {
        public T InjectedValue;

        public ClassWithOneGenericParameter(string s, object o)
        {
        }

        public ClassWithOneGenericParameter(T injectedValue)
        {
            InjectedValue = injectedValue;
        }
    }
}
