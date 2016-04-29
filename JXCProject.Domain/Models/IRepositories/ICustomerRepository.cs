using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Modify(Customer entity, List<CustomerAddress> customerAddresses);
        IEnumerable<Customer> GetCustomerByTypeOrName(string cstType, string cstName); 
    }
}
