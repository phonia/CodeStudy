using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer : BaseEntity<string>
    {
        /// <summary>
        /// 简称
        /// </summary>
        public string SimpleID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public string CstType { get; set; }

        /// <summary>
        /// 客户收货地址
        /// </summary>
        public virtual IList<CustomerAddress> CustomerAddresses { get; set; }
        /// <summary>
        /// 入库单
        /// </summary>
        public virtual IList<InStore> InStores { get; set; }
        /// <summary>
        /// 采购单
        /// </summary>
        public virtual  IList<PurchaseOp> PurchaseOps { get; set; }
        /// <summary>
        /// 销售单
        /// </summary>
        public virtual IList<SaleOrder> SaleOrdres { get; set; }
    }
}
