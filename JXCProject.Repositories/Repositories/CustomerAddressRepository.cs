using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Repositories;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories
{
    public class CustomerAddressRepository : Repository<CustomerAddress>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(JXCContext unitOfWork)
            : base(unitOfWork)
        { }

        public IEnumerable<CustomerAddress> GetCustomerAddressByCustomerId(string cstId)
        {
            return base.GetByWhere(o => o.CustomerId == cstId);
        }
    }
}
