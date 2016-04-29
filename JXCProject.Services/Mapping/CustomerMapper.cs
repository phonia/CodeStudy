using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.DTOs;
using JXCProject.Domain.Models;
using AutoMapper;

namespace JXCProject.Services.Mapping
{
    public static class CustomerMapper
    {
        public static CustomerDTO ConvertToCustomerDto(this Customer customer)
        {
            return Mapper.Map<Customer, CustomerDTO>(customer);
        }

        public static Customer ConvertToCustomer(this CustomerDTO customer)
        {
            return Mapper.Map<CustomerDTO, Customer>(customer);
        }

        public static IEnumerable<CustomerDTO> ConvertToCustomerDtos(this IEnumerable<Customer> customers)
        {
            return MapperHelper.Map<Customer, CustomerDTO>(customers);
        }

        public static IEnumerable<CustomerAddressDTO> ConvertToCustomerAddressDtos(this IEnumerable<CustomerAddress> customerAddresses)
        {
            return MapperHelper.Map<CustomerAddress, CustomerAddressDTO>(customerAddresses);
        }

        public static IEnumerable<CustomerAddress> ConvertToCustomerAddresses(this IEnumerable<CustomerAddressDTO> customerAddressDtos)
        {
            return MapperHelper.Map<CustomerAddressDTO, CustomerAddress>(customerAddressDtos);
        } 
    }
}
