using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 客户收货地址
    /// </summary>
   public  class CustomerAddress:BaseEntity<Guid>
    {
       /// <summary>
       /// 收货人
       /// </summary>
       public string Reciever { get; set; }
       /// <summary>
       /// 收货地址
       /// </summary>
       public string Address { get; set; }
       /// <summary>
       /// 邮编
       /// </summary>
       public string ZipCode { get; set; }
       /// <summary>
       /// 电话
       /// </summary>
       public string Telephone { get; set; }
       /// <summary>
       /// 客户Id
       /// </summary>
       public string CustomerId { get; set; }
       /// <summary>
       /// 客户
       /// </summary>
       public  Customer Customer { get; set; }
    }
}
