﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    public interface IPurchaseOpDetailRepository : IRepository<PurchaseOpDetail>
    {
        IEnumerable<PurchaseOpDetail> GetPurchaseOpDetailById(string purchaseOpId);
    }
}
