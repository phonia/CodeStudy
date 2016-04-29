using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 品种
    /// </summary>
    public class Product:BaseEntity<string>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string SimpleName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 批发价格
        /// </summary>
        public decimal TradePrice { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Producer { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime ProductDate { get; set; }
        /// <summary>
        /// 品种分类Id
        /// </summary>
        public string ProductCategoryId { get; set; }
        /// <summary>
        /// 品种分类
        /// </summary>
        public virtual ProductCategory ProductCategory { get; set; }
        /// <summary>
        /// 采购单明细 
        /// </summary>
        public virtual IList<PurchaseOpDetail> PurchaseOpDetails { get; set; }
        /// <summary>
        /// 入库单
        /// </summary>
        public virtual IList<InStore> InStores { get; set; }
        /// <summary>
        /// 公司货位库存
        /// </summary>
        public virtual IList<PositionStock> PositionStocks { get; set; }
        /// <summary>
        /// 销售单明细
        /// </summary>
        public virtual IList<SaleOrderDetail> SaleOrderDetails { get; set; }
    }
}
