using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXCProject.Web.Infrastructure;
using JXCProject.Controllers.Controllers;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services.DTOs;

namespace JXCProject.Web.Controllers.Basic
{
    public class DepartmentController : BaseController
    {
        IDepartmentService deptService;

        public DepartmentController()
        { }

        public DepartmentController(IDepartmentService deptService)
        {
            this.deptService = deptService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public void AddDepartment(DepartmentDTO dept)
        {
            deptService.AddDepartment(dept);
        }

        public void RemoveDepartment(DepartmentDTO dept)
        {
            deptService.RemoveDepartment(dept); 
        }

        public void ModifyDepartment(DepartmentDTO dept)
        {
            deptService.ModifyDepartment(dept);
        }

        public JsonResult GetPageData()
        {
            int recordCount;
            var data= deptService.GetPageData(PageDescriptor.PageIndex, PageDescriptor.PageCount, PageDescriptor.Sort, PageDescriptor.Order, out recordCount);
            return Json(new { total = recordCount, rows = data.ToList() });
        }

        public JsonResult CreateDepartmentTree()
        { 
            return Json(AddTopDepartment(),JsonRequestBehavior.AllowGet);
        }

        private List<object> AddTopDepartment()
        {
            var data = deptService.GetDepartmentsByParentId(null);
            var nodes = new List<object>(); 
            foreach (var o in data)
            {
                TreeDescriptor tree = new TreeDescriptor();
                tree.Id = o.ID;
                tree.Text = o.Name;
                tree.Children = AddChildrenDepartment(o.ID);
                nodes.Add(new { id = tree.Id, text = tree.Text, children = tree.Children });
            }
            return nodes;
        }

        private List<object> AddChildrenDepartment(string parentId)
        {
            var data = deptService.GetDepartmentsByParentId(parentId);
            var nodes = new List<object>();
            foreach (var o in data)
            {
                TreeDescriptor tree = new TreeDescriptor();
                tree.Id = o.ID;
                tree.Text = o.Name;
                tree.Children = AddChildrenDepartment(o.ID);
                nodes.Add(new { id = tree.Id, text = tree.Text, children = tree.Children });
            }
            return nodes;
        }
    }
}
