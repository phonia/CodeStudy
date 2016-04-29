using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.Interfaces.Purchase;
using System.Web.Mvc;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services;
using JXCProject.Services.DTOs;

namespace JXCProject.Controllers.Controllers.Purchase
{
    public class PurchaseController : BaseController
    {
        IPurchaseOpService purchaseOpService;

        public PurchaseController() { }

        public PurchaseController(IPurchaseOpService purchaseOpService)
        {
            this.purchaseOpService = purchaseOpService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PurchaseApply()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ModifyPurchase()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PurchaseApprove()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PurchaseManage()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCustomerByName(string cstName)
        {
            var data = purchaseOpService.GetPurchaseCustomerByName(cstName);

            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProudct(string categoryId, string name)
        {
            var data = purchaseOpService.GetProductByCategoryIdAndName(categoryId, name);
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PurchaseApply(PurchaseOpDTO purchase)
        {
            if (ModelState.IsValid)
            {
                purchase.ID = BaseDTO.RenderID();
                purchase.Appor = "admin";
                purchase.AppDate = DateTime.Now;
                purchase.State = DataDictionary.Apply;
                purchase.Customer = null;

                foreach (var purchaseDetail in purchase.PurchaseOpDetails)
                {
                    purchaseDetail.ID = BaseDTO.RenderID();
                    purchaseDetail.PurchaseOpId = purchase.ID;
                    purchaseDetail.AprQty = 0;
                    purchaseDetail.PurchaseOp = null;
                    purchaseDetail.Product = null;
                }
                purchaseOpService.PurchaseApply(purchase);

                return Json(null);
            }
            return Json(GetErrorMessages(), "text/html", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PurchaseApprove(PurchaseOpDTO purchase)
        {
            if (ModelState.IsValid)
            {
                purchaseOpService.PurchaseApprove(purchase);

                return Json(null);
            }
            return Json(GetErrorMessages(), "text/html", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetForApprovedPurchaseOp(string purchaseOpId)
        {
            var data = purchaseOpService.GetForApprovedPurchaseOp(purchaseOpId);
            return CustomJson(new { total = data.Count(), rows = data == null ? null : data.ToList() });
        }

        [HttpPost]
        public JsonResult GetPurchaseOpIds()
        {
            var data = purchaseOpService.GetForApprovedPurchaseOpIds(DataDictionary.Apply);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPageData(string cstId, string productId, DateTime startDate, DateTime endDate)
        {
            if (startDate != null && endDate != null)
            {
                cstId = cstId == DataDictionary.PleaseSelect ? null : cstId;
                productId = productId == DataDictionary.PleaseSelect ? null : productId;
                int recordCount;
                var data = purchaseOpService.GetPageData(PageDescriptor.PageIndex, PageDescriptor.PageCount, cstId, productId, startDate, endDate, PageDescriptor.Sort, PageDescriptor.Order, out recordCount).ToList();

                return CustomJson(new { total = recordCount, rows = data });
            }
            else return Json(null);
        }

        [HttpPost]
        public void RemovePurchase(PurchaseOpAndDetailDTO purchaseOp)
        {
            purchaseOpService.RemovePurchase(purchaseOp);
        }

        [HttpPost]
        public JsonResult GetPurchaseOpDetail(string purchaseOpId)
        {
           var data=  purchaseOpService.GetPurchaseOpDetailById(purchaseOpId).ToList();
           return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
