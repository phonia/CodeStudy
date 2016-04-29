using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;

namespace JXCProject.BLL.Basic.IBLL
{
    public  interface ICustomerMT
    {
        void AddCustomer(Customer customer);
        void ModifyCustomer(Customer customer,List<CustomerAdress> customerAddresses);
        void RemoveCustomer(Customer customer);
        IEnumerable<CustomerAdress> GetCustomerAddressByCustomerId(string cstId);
        IEnumerable<Customer> GetPageData(int pageIndex, int pageCount, string cstType, string cstName, string orderText, bool ascending, out int recordCount);
    }
}
