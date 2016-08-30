using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiLanguageRes.Models;

namespace MultiLanguageRes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            try
            {
                CultureInfo.CurrentCulture.Name=
                var pp = new Product();
                return View(pp);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
