using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Repositories;
using JXCProject.Domain.Models;
using System.Data.Entity;
using JXCProject.Infrastructure.Extesions;

namespace JXCProject.Repositories
{
    public class PurchaseOpRepository : Repository<PurchaseOp>, IPurchaseOpRepository
    {
        public PurchaseOpRepository(JXCContext unitOfWork)
            : base(unitOfWork) { }


        public PurchaseOp GetPurchaseOpById(string purchaseOpId, bool isLoadCustomer)
        {
            JXCContext unitOfWork = base.UnitOfWork as JXCContext;

            var purchaseOp = unitOfWork.PurchaseOp.Include(o => o.PurchaseOpDetails).
                SingleOrDefault(o => o.ID == purchaseOpId);

            if (isLoadCustomer)
                unitOfWork.Entry(purchaseOp).Reference(o => o.Customer).Load();

            return purchaseOp;
        }

        public IEnumerable<PurchaseOp> GetPurchaseOpBy(string cstId, string productId, DateTime startDate, DateTime endDate)
        {
            JXCContext unitOfWork = base.UnitOfWork as JXCContext;

            var purchaseOp = unitOfWork.PurchaseOp.Include(o => o.Customer).Include(o => o.PurchaseOpDetails);
            purchaseOp.Load();

            purchaseOp = purchaseOp.Where(o => o.Date >= startDate && o.Date <= endDate);

            if (!string.IsNullOrEmpty(cstId))
                purchaseOp = purchaseOp.Where(o => o.CustomerId == cstId);

            if (!string.IsNullOrEmpty(productId))
                purchaseOp = purchaseOp.Where(o => o.PurchaseOpDetails.Where(p => p.ProductId == productId).Count() > 0);

            return purchaseOp;
        }

    }
}
