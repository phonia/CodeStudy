using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JXCProject.Web.Infrastructure
{
    public class TreeDescriptor
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string State { get; set; }
        public List<object> Children { get; set; }
    }
}