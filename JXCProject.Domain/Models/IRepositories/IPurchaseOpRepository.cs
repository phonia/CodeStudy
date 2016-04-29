using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    public interface IPurchaseOpRepository : IRepository<PurchaseOp>
    {
        PurchaseOp GetPurchaseOpById(string purchseOpId, bool isLoadCustomer); 
        IEnumerable<PurchaseOp> GetPurchaseOpBy(string cstId, string productId, DateTime startDate, DateTime endDate);
    }
}
