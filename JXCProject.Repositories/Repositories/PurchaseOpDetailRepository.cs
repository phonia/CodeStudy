using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Repositories;
using JXCProject.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace JXCProject.Repositories
{
    public class PurchaseOpDetailRepository : Repository<PurchaseOpDetail>, IPurchaseOpDetailRepository
    {
        public PurchaseOpDetailRepository(JXCContext unitOfWork)
            : base(unitOfWork)
        { }

        public IEnumerable<PurchaseOpDetail> GetPurchaseOpDetailById(string purchaseOpId)
        {
            JXCContext unitOfWork = base.UnitOfWork as JXCContext;
            var query= unitOfWork.PurchaseOpDetail.Include(o => o.Product).Where(o => o.PurchaseOpId == purchaseOpId);
            return query;
        }
    }
}
