using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.DTOs;

namespace JXCProject.Services.Interfaces.Basic
{
   public  interface ICustomerService
    {
        void AddCustomer(CustomerDTO customerDto);
        void ModifyCustomer(CustomerDTO customerDto, List<CustomerAddressDTO> customerAddressesDto);
        void RemoveCustomer(CustomerDTO customerDto);
        IEnumerable<CustomerAddressDTO> GetCustomerAddressByCustomerId(string cstId);
        IEnumerable<CustomerDTO> GetPageData(int pageIndex, int pageCount, string cstType, string cstName, string orderText, bool ascending, out int recordCount);
    }
}
