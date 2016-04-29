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
    /// 销售单明细
    /// </summary>
    public class SaleOrderDetail : BaseEntity<string>
    {
        [NotMapped]
        public override string ID { get; set; }
        /// <summary>
        /// 库存底价
        /// </summary>
        public decimal StoPrice { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal DetlAmount
        {
            get { return Discount != decimal.Zero ? SalePrice * OutQty * Discount : SalePrice * OutQty; }
        }
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
        /// 人员Id
        /// </summary>
        public Guid EmpId { get; set; }
        /// <summary>
        /// 品种Id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 销售单Id
        /// </summary>
        public string SaleOrderId { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public Product Product{ get; set; }
        /// <summary>
        /// 销售单
        /// </summary>
        public SaleOrder SaleOrder { get; set; }
        /// <summary>
        /// 职工
        /// </summary>
        public Employee Employee { get; set; }
        /// <summary>
        /// 销售出库
        /// </summary>
        public IList<SaleOut> SaleOuts { get; set; }
    }
}
