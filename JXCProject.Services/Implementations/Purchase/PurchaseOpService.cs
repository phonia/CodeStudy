using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.Interfaces.Purchase;
using JXCProject.Services.DTOs;
using JXCProject.Domain.Models;
using JXCProject.Services.Mapping;
using JXCProject.Infrastructure.Extesions;

namespace JXCProject.Services.Implementations.Purchase
{
    public class PurchaseOpService : IPurchaseOpService
    {
        IPurchaseOpRepository purchaseOpRepository;
        ICustomerRepository customerRepository;
        IProductRepository productRepository;
        IPurchaseOpDetailRepository purchaseOpDetailRepository;

        public PurchaseOpService(IPurchaseOpRepository purchaseOpRepository, ICustomerRepository customerRepository,
            IProductRepository productRepository, IPurchaseOpDetailRepository purchaseOpDetailRepository)
        {
            this.purchaseOpRepository = purchaseOpRepository;
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
            this.purchaseOpDetailRepository = purchaseOpDetailRepository;
        }

        public void PurchaseApply(PurchaseOpDTO purchase)
        {
            purchaseOpRepository.Add(purchase.ConvertToPurchaseOp());
            purchaseOpRepository.UnitOfWork.Commite();
        }

        public void PurchaseApprove(PurchaseOpDTO purchase)
        {
            var originalPurchaseOp = purchaseOpRepository.GetPurchaseOpById(purchase.ID, false);

            originalPurchaseOp.Apror = "admin";
            originalPurchaseOp.AprDate = DateTime.Now;
            originalPurchaseOp.State = purchase.State;
            for (int i = 0; i < originalPurchaseOp.PurchaseOpDetails.Count; i++)
            {
                originalPurchaseOp.PurchaseOpDetails[i].AprQty = purchase.PurchaseOpDetails[i].AprQty;
            }
            purchaseOpRepository.Modify(originalPurchaseOp);
            purchaseOpRepository.UnitOfWork.Commite();
        }

        public void ModifyPurchase(PurchaseOpDTO purchase)
        {
            purchaseOpRepository.Modify(purchase.ConvertToPurchaseOp());
            purchaseOpRepository.UnitOfWork.Commite();
        }

        public void RemovePurchase(PurchaseOpAndDetailDTO purchase)
        {
            PurchaseOp op = new PurchaseOp { ID = purchase.PurchaseOpId };
            purchaseOpRepository.Remove(op);
            purchaseOpRepository.UnitOfWork.Commite();
        }

        public IEnumerable<CustomerDTO> GetPurchaseCustomerByName(string cstName)
        {
            var customers = customerRepository.GetCustomerByTypeOrName(DataDictionary.PurchaseCustomer, cstName);
            return customers.ConvertToCustomerDtos();
        }

        public IEnumerable<ProductDTO> GetProductByCategoryIdAndName(string categoryId, string name)
        {
            var products = productRepository.GetProductByCategoryIdAndName(categoryId, name);
            return products.ConvertToProductDtos();
        }

        public IEnumerable<PurchaseOpAndDetailDTO> GetForApprovedPurchaseOp(string purchaseOpId)
        {
            if (string.IsNullOrEmpty(purchaseOpId) || purchaseOpId == DataDictionary.PleaseSelect) return new List<PurchaseOpAndDetailDTO>();

            var purchaseOp = purchaseOpRepository.GetPurchaseOpById(purchaseOpId, true);
            var pods = new List<PurchaseOpAndDetailDTO>();

            foreach (var purchaseOpDetail in purchaseOp.PurchaseOpDetails)
            {
                PurchaseOpAndDetailDTO pod = new PurchaseOpAndDetailDTO();
                pod.PurchaseOpId = purchaseOp.ID;
                pod.CustomerName = purchaseOp.Customer.Name;
                pod.ProductName = productRepository.GetProductById(purchaseOpDetail.ProductId).Name;
                pod.AppQty = purchaseOpDetail.AppQty;
                pod.AprQty = purchaseOpDetail.AppQty;
                pod.Appor = purchaseOp.Appor;
                pod.AppDate = purchaseOp.AppDate;
                pod.Date = purchaseOp.Date;

                pods.Add(pod);
            }
            return pods;
        }

        public IEnumerable<PurchaseOpAndDetailDTO> GetForApprovedPurchaseOpIds(string state)
        {
            var purchaseOpIds = purchaseOpRepository.GetByWhere(o => o.State == state).
                Select(p => new PurchaseOpAndDetailDTO { PurchaseOpId = p.ID });
            return purchaseOpIds;
        }

        public IEnumerable<PurchaseOpAndDetailDTO> GetPageData(int pageIndex, int pageCount, string cstId, string productId, DateTime startDate, DateTime endDate, string orderText, bool ascending, out int recordCount)
        {
            var query = purchaseOpRepository.GetPurchaseOpBy(cstId, productId, startDate, endDate);
            var pods = new List<PurchaseOpAndDetailDTO>();

            recordCount = query.Count();
            query = query.Paging(pageIndex, pageCount, orderText, ascending);
            foreach (var o in query)
            {
                PurchaseOpAndDetailDTO pod = new PurchaseOpAndDetailDTO();
                pod.PurchaseOpId = o.ID;
                pod.CustomerName = o.Customer.Name;
                pod.Amount = o.Amount;
                pod.Appor = o.Appor;
                pod.AppDate = o.AppDate;
                pod.Date = o.Date;
                pod.State = o.State;
                pods.Add(pod);
            }
            return pods;
        }

        public IEnumerable<PurchaseOpAndDetailDTO> GetPurchaseOpDetailById(string purchaseOpId)
        {
            var purchaseOpDetails = purchaseOpDetailRepository.GetPurchaseOpDetailById(purchaseOpId);
            List<PurchaseOpAndDetailDTO> pods = new List<PurchaseOpAndDetailDTO>();

            foreach (var detail in purchaseOpDetails)
            {
                PurchaseOpAndDetailDTO pod = new PurchaseOpAndDetailDTO();
                pod.ProductName = detail.Product.Name;
                pod.AppQty = detail.AppQty;
                pod.AprQty = detail.AprQty;
                pod.StkPrice = detail.StkPrice;
                pod.Amount = detail.StkAmount;
                pod.RecQty = detail.RecQty;
                pods.Add(pod);
            }
            return pods;
        }
    }
}
