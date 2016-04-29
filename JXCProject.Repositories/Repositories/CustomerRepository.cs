using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Repositories;
using JXCProject.Domain.Models;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;

namespace JXCProject.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(JXCContext unitOfWork)
            : base(unitOfWork)
        { }

        public void Modify(Customer customer, List<CustomerAddress> customerAddresses)
        {
            var uniteOfWork = base.UnitOfWork as JXCContext;

            uniteOfWork.Customer.Add(customer);

            //修改Customer
            uniteOfWork.Entry(customer).State = EntityState.Modified;

            //新增CustomerAddress
            foreach (var address in customerAddresses)
            {
                if (GetTempCustomerAddress(customer).All(o => o.ID != address.ID))
                {
                    customer.CustomerAddresses.Add(address);
                }
            }
            //删除CustomerAddress
            foreach (var address in GetTempCustomerAddress(customer))
            {
                if (customerAddresses.All(o => o.ID != address.ID))
                {
                    uniteOfWork.Entry(address).State = EntityState.Deleted;
                }
            }
        }

        public IEnumerable<Customer> GetCustomerByTypeOrName(string cstType, string cstName)
        {
            var customers = base.GetByWhere(o => o.CstType == cstType, true);
            if (!string.IsNullOrEmpty(cstName))
                customers = customers.Where(o => o.Name.Contains(cstName) || o.SimpleID.Contains(cstName));
            return customers;
        }

        private List<CustomerAddress> GetTempCustomerAddress(Customer customer)
        {
            var uniteOfWork = base.UnitOfWork as JXCContext;

            var query = uniteOfWork.Customer.Include(o => o.CustomerAddresses).Single(o => o.ID == customer.ID);
            var addresses = new List<CustomerAddress>();
            addresses.AddRange(query.CustomerAddresses);

            return addresses;
        }
    }
}
