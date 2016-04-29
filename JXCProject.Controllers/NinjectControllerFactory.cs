using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using JXCProject.Domain.Models;
using JXCProject.Repositories;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services.Implementations.Basic;
using JXCProject.Services.CacheStorage;
using JXCProject.Services.Interfaces.Purchase;
using JXCProject.Services.Implementations.Purchase;

namespace JXCProject.Controllers
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IProductCategoryRepository>().To<ProductCategoryRepository>();
            ninjectKernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
            ninjectKernel.Bind<IProductRepository>().To<ProductRepository>();
            ninjectKernel.Bind<IProductService>().To<ProductService>();
            ninjectKernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            ninjectKernel.Bind<IDepartmentService>().To<DepartmentService>();
            ninjectKernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            ninjectKernel.Bind<IEmployeeService>().To<EmployeeService>();
            ninjectKernel.Bind<ICustomerService>().To<CustomerService>();
            ninjectKernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            ninjectKernel.Bind<ICustomerAddressRepository>().To<CustomerAddressRepository>();
            ninjectKernel.Bind<IPurchaseOpRepository>().To<PurchaseOpRepository>();
            ninjectKernel.Bind<IPurchaseOpService>().To<PurchaseOpService>();
            ninjectKernel.Bind<IPurchaseOpDetailRepository>().To<PurchaseOpDetailRepository>();
            ninjectKernel.Bind<ICacheStorage>().To<HttpContextCacheAdapter>();
        }
    }
}