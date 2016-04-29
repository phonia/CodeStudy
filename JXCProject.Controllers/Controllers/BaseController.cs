using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using JXCProject.Web.Infrastructure;

namespace JXCProject.Controllers.Controllers
{
   public  class BaseController:Controller
    {
        private PageDescriptor pageDescriptor;

        public PageDescriptor PageDescriptor
        {
            get { return pageDescriptor; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            if (request["rows"] != null && request["page"] != null)
            {
                pageDescriptor = new PageDescriptor();
                pageDescriptor.PageCount = int.Parse(request["rows"]);
                pageDescriptor.PageIndex = int.Parse(request["page"]) - 1;
                pageDescriptor.Order = request["order"] == "asc" ? true : false;
                pageDescriptor.Sort = request["sort"];
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected virtual CustomJsonResult CustomJson(object data, JsonRequestBehavior behavior, string formatter)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = behavior, Formatter = formatter };
        }

        protected virtual CustomJsonResult CustomJson(object data)
        {
            return CustomJson(data, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");
        }

        protected virtual List<object> GetErrorMessages()
        {
            List<object> errors = new List<object>();
            
            foreach (var key in ModelState.Keys)
            {
                if (ModelState[key].Errors.Count > 0)
                {
                    var obj = new { key = key, errorMessage = ModelState[key].Errors.Select(o =>o.ErrorMessage).First() };
                    errors.Add(obj);
                }
            } 
            return errors;
        }
    }
}
