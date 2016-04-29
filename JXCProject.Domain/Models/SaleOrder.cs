using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 销售单
    /// </summary>
    public class SaleOrder : BaseEntity<string>
    {
        /// <summary>
        /// 销售类型
        /// </summary>
        public string SaleType { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public decimal SaleQty { get; set; }
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal SaleAmount { get; set; }
        /// 销售日期
        /// </summary>
        public DateTime SaleDate { get; set; }
        /// <summary>
        /// 出库量
        /// </summary>
        public decimal OutQty { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public string Opor { get; set; }
        /// <summary>
        /// 录入日期
        /// </summary>
        public DateTime OpDate { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// 销售单明细
        /// </summary>
        public IList<SaleOrderDetail> SaleOrderDetails { get; set; }
    }
}
