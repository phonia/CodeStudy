using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXCProject.Domain.Models;
using JXCProject.Web.Infrastructure;
using JXCProject.Controllers.Controllers;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services.DTOs;
using JXCProject.Services;

namespace JXCProject.Web.Controllers.Basic
{
    public class ProductController : BaseController
    {
        IProductService productService;

        public ProductController()
        {

        }

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ModifyProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                productService.AddProduct(product);
                return Json(null);
            }
            else
                return Json(GetErrorMessages(), "text/html", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateProductName(string productName)
        {
            int count= productService.GetProductCountByName(productName);
            return Json(count == 0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPageData(string categoryId, string productId, string simpleName)
        {
            int recordCount;
            categoryId = categoryId == DataDictionary.PleaseSelect ? null : categoryId;
            productId = productId == DataDictionary.PleaseSelect ? null : productId;
            var query = productService.GetPageData(PageDescriptor.PageIndex, PageDescriptor.PageCount, categoryId, productId, simpleName, PageDescriptor.Sort, PageDescriptor.Order, out recordCount);

            return CustomJson(new { total = recordCount, rows = query.ToList() });
        }

        public JsonResult LoadProducts(string categoryId)
        {
            var data = productService.GetProductByCategoryId(categoryId);
            return Json(data);
        }

        [HttpPost]
        public ActionResult ModifyProduct(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                productService.ModifyProduct(product);
                return Json(null);
            }
            else
                return Json(GetErrorMessages(), "text/html", JsonRequestBehavior.AllowGet);
        }

        public void RemoveProduct(ProductDTO product)
        {
            productService.RemoveProduct(product);
        }
    }
}
