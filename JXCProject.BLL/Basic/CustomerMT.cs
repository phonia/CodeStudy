using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.BLL.Basic.IBLL;
using JXCProject.Domain.Models;
using JXCProject.BLL.CacheStorage;

namespace  JXCProject.Bll.Basic
{
    public class CustomerMT : ICustomerMT
    {
        ICustomerRepository customerRepository;
        ICustomerAddressRepository customerAddressRepository;
        ICacheStorage cache;

        public CustomerMT(ICustomerRepository customerRepository, ICustomerAddressRepository customerAddressRepository,ICacheStorage cache)
        {
            this.customerRepository = customerRepository;
            this.customerAddressRepository = customerAddressRepository;
            this.cache = cache;
        }

        public void AddCustomer(Customer customer)
        {
            customer.ID = customer.GetID();
            customerRepository.Add(customer);
            customerRepository.UnitOfWork.Commite();
        }

        public void ModifyCustomer(Customer customer, List<CustomerAdress> customerAddresses)
        {
            customerRepository.Modify(customer,customerAddresses);
            customerRepository.UnitOfWork.Commite();
        }

        public void RemoveCustomer(Customer customer)
        {
            customerRepository.Remove(customer);
            customerRepository.UnitOfWork.Commite();
        }

        public IEnumerable<Customer> GetPageData(int pageIndex, int pageCount, string cstType, string cstName, string orderText, bool ascending, out int recordCount)
        {
            var customers = customerRepository.GetByWhere(o => o.CstType == cstType && o.Name.Contains(cstName),true);
            recordCount = customers.Count();
            return customerRepository.GetAll(pageIndex, pageCount, customers, orderText, ascending);
        }

        public IEnumerable<CustomerAdress> GetCustomerAddressByCustomerId(string cstId)
        {
            return customerAddressRepository.GetCustomerAddressByCustomerId(cstId); 
        }
    }
}
