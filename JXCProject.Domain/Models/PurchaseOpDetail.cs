using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 采购单明细
    /// </summary>
    public class PurchaseOpDetail : BaseEntity<string>
    {
        /// <summary>
        /// 采购申请量
        /// </summary>
        public decimal AppQty { get; set; }
        /// <summary>
        /// 采购审批量
        /// </summary>
        public decimal AprQty { get; set; }
        /// <summary>
        /// 采购价格
        /// </summary>
        public decimal StkPrice { get; set; }
        /// <summary>
        /// 采购金额
        /// </summary>
        public decimal StkAmount
        {
            get { return AprQty * StkPrice; }
        }
        /// <summary>
        /// 实际收货数量
        /// </summary>
        public decimal? RecQty { get; set; }
        /// <summary>
        /// 品种Id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 采购单Id
        /// </summary>
        public string PurchaseOpId { get; set; }
        /// <summary>
        /// 采购单
        /// </summary>
        public virtual PurchaseOp PurchaseOp { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
