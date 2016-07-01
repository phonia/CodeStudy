using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityStudy
{
    public class TypeWithArrayConstructorParameter
    {
        public readonly ILogger[] loggers;

        public TypeWithArrayConstructorParameter(ILogger[] loggers)
        {
            this.loggers = loggers;
        }
    }
}
