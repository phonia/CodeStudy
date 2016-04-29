using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXCProject.Domain.Models;
using JXCProject.Web.Infrastructure;
using JXCProject.Controllers.Controllers;
using JXCProject.Services.Interfaces.Basic;

namespace JXCProject.Web.Controllers.Basic
{
    public class ProductCategoryController :BaseController
    {
        IProductCategoryService productCategoryService;

        public ProductCategoryController()
        {
            
        }

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        public ActionResult Index(string categoryName)
        {
            return View();
        }

        public JsonResult GetPageData(string cName)
        {
            int recordCount;
            var productCategories = productCategoryService.GetPageData(cName, PageDescriptor.PageIndex, PageDescriptor.PageCount, PageDescriptor.Sort, PageDescriptor.Order, out recordCount);
            return Json(new { total = recordCount, rows = productCategories.ToList() });
        }

        public void ModifyProductCategory(string parentID,string id)
        {
            productCategoryService.ModifyProductCategory(parentID, id);
        }

        public void AddProductCategory(string parentID,string categoryName)
        {
            productCategoryService.AddProductCategory(parentID, categoryName);
        }

        public void RemoveProductCategory(string id)
        {
            productCategoryService.RemoveProductCategory(id);
        }

        public JsonResult CreateCategoryTree()
        {
            return Json(AddTopCategory());
        }

        private List<object> AddTopCategory()
        {
            var data = productCategoryService.GetProductCategoriesByParentId(null);
            var nodes = new List<object>();
            foreach (var o in data)
            {
                TreeDescriptor tree = new TreeDescriptor();
                tree.Id = o.ID;
                tree.Text = o.CategoryName;
                tree.Children = AddChildrenCategory(o.ID);
                nodes.Add(new { id = tree.Id, text = tree.Text, children = tree.Children });
            }
            return nodes;
        }

        private List<object> AddChildrenCategory(string parentId)
        {
            var data = productCategoryService.GetProductCategoriesByParentId(parentId);
            var nodes = new List<object>();
            foreach (var o in data)
            {
                TreeDescriptor tree = new TreeDescriptor();
                tree.Id = o.ID;
                tree.Text = o.CategoryName;
                tree.Children = AddChildrenCategory(o.ID);
                nodes.Add(new { id = tree.Id, text = tree.Text, children = tree.Children });
            }
            return nodes;
        }
    }
}
