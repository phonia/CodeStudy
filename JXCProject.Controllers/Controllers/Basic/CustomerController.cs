using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.Interfaces.Basic;
using System.Web.Mvc;
using JXCProject.Domain.Models;
using JXCProject.Services;
using JXCProject.Services.DTOs;

namespace JXCProject.Controllers.Controllers.Basic
{
    public class CustomerController : BaseController
    {
        private ICustomerService customerService;

        public CustomerController() { }

        public CustomerController(ICustomerService customerService)
        {
            //JXCProject.Repositories.CreateDatabaseFromModels.CreateDatabase();
            this.customerService = customerService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ModifyCustomer()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCustomer(CustomerDTO Customer)
        {
            if (ModelState.IsValid)
            {
                customerService.AddCustomer(Customer);
                return Json(null);
            }
            return Json(GetErrorMessages(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ModifyCustomer(CustomerDTO Customer, List<CustomerAddressDTO> customerAddresses)
        {
            if (ModelState.IsValid)
            {
                customerService.ModifyCustomer(Customer, customerAddresses);
                return Json(null);
            }
            return Json(GetErrorMessages(), "text/html", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void RemoveCustomer(CustomerDTO Customer)
        {
            customerService.RemoveCustomer(Customer);
        }

        [HttpPost]
        public JsonResult GetCustomerAddress(string cstId)
        {
            var data = customerService.GetCustomerAddressByCustomerId(cstId);
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPageData(string cstType, string cstName)
        {
            cstType = cstType == DataDictionary.PleaseSelect ? null : cstType;
            int recordCount;
            var data = customerService.GetPageData(PageDescriptor.PageIndex, PageDescriptor.PageCount, cstType, cstName, PageDescriptor.Sort, PageDescriptor.Order, out recordCount).ToList();
            return Json(new { total = recordCount, rows = data }, JsonRequestBehavior.AllowGet);
        }
    }
}
