using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 销售出库明细
    /// </summary>
   public  class SaleOutDetail:BaseEntity<Guid>
    {
       [NotMapped]
       public override Guid ID { get; set; }
       /// <summary>
       /// 出库数量
       /// </summary>
       public decimal DetlQty { get; set; }

       /// <summary>
       /// 公司货位Id
       /// </summary>
       public string WarePositionId { get; set; }
       /// <summary>
       /// 品种Id
       /// </summary>
       public string ProductId { get; set; }

       /// <summary>
       /// 销售出库Id
       /// </summary>
       public string SaleOutId { get; set; }
       /// <summary>
       /// 销售出库
       /// </summary>
       public SaleOut SaleOut { get; set; }
       /// <summary>
       /// 公司货位库存
       /// </summary>
       public PositionStock PositionStock { get; set; }
    }
}
