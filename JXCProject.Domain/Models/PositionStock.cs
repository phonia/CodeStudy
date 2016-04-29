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
    /// 公司货位库存
    /// </summary>
    public  class PositionStock:BaseEntity<Guid>
    {
        [NotMapped]
        public override  Guid ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get;set;}
        /// <summary>
        /// 入库量
        /// </summary>
        public decimal InQty { get; set; }
        /// <summary>
        /// 出库量
        /// </summary>
        public decimal OutQty { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public decimal StoQty { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ExpDate { get; set; }
        /// <summary>
        /// 公司货位Id
        /// </summary>
        public string WarePositionId { get; set; }
        /// <summary>
        /// 品种Id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 公司货位
        /// </summary>
        public WarePosition WarePostion { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 销售出库明细
        /// </summary>
        public IList<SaleOutDetail> SaleOutDetails { get; set; }
    }
}
