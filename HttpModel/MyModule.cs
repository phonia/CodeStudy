using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpModel
{
    public class MyModule:IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
        }
    }

    public class MyHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
           
        }
    }
}