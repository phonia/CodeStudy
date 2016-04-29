using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services.CacheStorage;
using JXCProject.Services.DTOs;
using JXCProject.Services.Mapping;
using JXCProject.Infrastructure.Extesions;

namespace JXCProject.Services.Implementations.Basic 
{
   public  class CustomerService:ICustomerService
    {
        ICustomerRepository customerRepository;
        ICustomerAddressRepository customerAddressRepository;
        ICacheStorage cache;

        public CustomerService(ICustomerRepository customerRepository, ICustomerAddressRepository customerAddressRepository, ICacheStorage cache)
        {
            this.customerRepository = customerRepository;
            this.customerAddressRepository = customerAddressRepository;
            this.cache = cache;
        }

        public void AddCustomer(CustomerDTO customerDto)
        {
            customerDto.ID = BaseDTO.RenderID();
            customerRepository.Add(customerDto.ConvertToCustomer());
            customerRepository.UnitOfWork.Commite();
        }

        public void ModifyCustomer(CustomerDTO customerDto, List<CustomerAddressDTO> customerAddressDto)
        {
            customerRepository.Modify(customerDto.ConvertToCustomer(), customerAddressDto.ConvertToCustomerAddresses().ToList());
            customerRepository.UnitOfWork.Commite();
        }

        public void RemoveCustomer(CustomerDTO customer)
        {
            customerRepository.Remove(customer.ConvertToCustomer());
            customerRepository.UnitOfWork.Commite();
        }

        public IEnumerable<CustomerDTO> GetPageData(int pageIndex, int pageCount, string cstType, string cstName, string orderText, bool ascending, out int recordCount)
        {
            var customers = customerRepository.GetCustomerByTypeOrName(cstType, cstName);
            recordCount = customers.Count();
            var result = customers.Paging(pageIndex, pageCount, orderText, ascending);
            return result.ConvertToCustomerDtos();
        }

        public IEnumerable<CustomerAddressDTO> GetCustomerAddressByCustomerId(string cstId)
        {
            var query= customerAddressRepository.GetCustomerAddressByCustomerId(cstId);
            return query.ConvertToCustomerAddressDtos();
        }
    }
}
