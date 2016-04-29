using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXCProject.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Script.Serialization;
using JXCProject.Controllers.Controllers;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services.DTOs;

namespace JXCProject.Web.Controllers.Basic
{
    public class EmployeeController : BaseController
    {
        IEmployeeService emService;

        public EmployeeController() { }

        public EmployeeController(IEmployeeService emService)
        {
            this.emService = emService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ModifyEmployee()
        {
            return View(); 
        }

        [HttpPost]
        public JsonResult AddEmployee(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                emService.AddEmployee(employee);
                return Json(null);
            }
            return Json(GetErrorMessages(),"text/html",JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ModifyEmployee(EmployeeDTO employee)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            EmployeeDTO originalEmployee = (EmployeeDTO)serializer.Deserialize(Request["originalEmployee"], typeof(EmployeeDTO));

            if (ModelState.IsValid)
            {
                emService.ModifyEmployee(originalEmployee, employee);
                return Json(null);
            }
            return Json(GetErrorMessages(), "text/html", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void RemoveEmployee(EmployeeDTO employee)
        {
            emService.RemoveEmployee(employee);
        }

        [HttpPost]
        public JsonResult GetPageData(string departmentId, string employeeName)
        {
            int recordCount;
            departmentId = departmentId == "--请选择--" ? null : departmentId;
            var data = emService.GetPageData(PageDescriptor.PageIndex, PageDescriptor.PageCount, departmentId, employeeName, PageDescriptor.Sort, PageDescriptor.Order, out recordCount);
            return CustomJson(new { total = recordCount, rows = data.ToList() });
        }
    }
}
