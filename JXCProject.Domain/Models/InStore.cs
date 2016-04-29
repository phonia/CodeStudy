using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 入库单
    /// </summary>
   public  class InStore:BaseEntity<string>
    {
       /// <summary>
       /// 入库类型
       /// </summary>
       public string Type { get; set; }
       /// <summary>
       /// 入库数量
       /// </summary>
       public decimal Qty { get; set; }
       /// <summary>
       /// 退货入库数量
       /// </summary>
       public decimal RetQty { get; set; }
       /// <summary>
       /// 入库金额
       /// </summary>
       public decimal Sum { get; set; }
       /// <summary>
       /// 入库日期
       /// </summary>
       public DateTime Date { get; set; }
       /// <summary>
       /// 操作人
       /// </summary>
       public string Opor { get; set; }

       /// <summary>
       /// 客户Id
       /// </summary>
       public string CustomerId { get; set; }
       /// <summary>
       /// 品种Id
       /// </summary>
       public string ProductId { get; set; }
       /// <summary>
       /// 入库明细
       /// </summary>
       public IList<InStoreDetail> InStoreDetails { get; set; }
       /// <summary>
       /// 客户
       /// </summary>
       public Customer Customer { get; set; }
       /// <summary>
       /// 品种
       /// </summary>
       public Product Product { get; set; }
    }
}
