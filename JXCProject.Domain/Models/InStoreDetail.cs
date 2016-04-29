using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 入库明细
    /// </summary>
   public  class InStoreDetail:BaseEntity<Guid>
    {
       /// <summary>
       /// 入库数量
       /// </summary>
       public int Qty { get; set; }
       /// <summary>
       /// 有效期
       /// </summary>
       public DateTime ExpDate { get; set; }
       /// <summary>
       /// 入库单Id
       /// </summary>
       public string InStoreId { get; set; }
       /// <summary>
       /// 入库单
       /// </summary>
       public InStore InStore { get; set; }
       /// <summary>
       /// 公司货位
       /// </summary>
       public IList<WarePosition> WarePositions { get; set; }
    }
}
