using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JXCProject.Web.Infrastructure
{
    public class PageDescriptor
    {
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public string Sort { get; set; }
        public bool Order { get; set; }
    }
}