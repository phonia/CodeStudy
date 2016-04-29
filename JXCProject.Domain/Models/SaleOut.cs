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
    /// 销售出库
    /// </summary>
    public  class SaleOut:BaseEntity<string>
    {
        /// <summary>
        /// 出库类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// 货运单号
        /// </summary>
        public string FreightNo { get; set; }
        /// <summary>
        /// 货运方式
        /// </summary>
        public string SendType { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string Rceiver { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string RevAddress { get; set; }
        /// <summary>
        /// 收货邮编
        /// </summary>
        public string RevZip { get; set; }
        /// <summary>
        /// 收货电话
        /// </summary>
        public string RevPhone { get; set; }
        /// <summary>
        /// 出库日期
        /// </summary>
        public string OutDate { get; set; }
        /// <summary>
        /// 出库人
        /// </summary>
        public string Opor { get; set; }
        /// <summary>
        /// 销售出库明细
        /// </summary>
        public IList<SaleOutDetail> SaleOutDetails { get; set; }
        /// <summary>
        /// 销售明细
        /// </summary>
        public SaleOrderDetail SaleOrderDetail { get; set; }
    }
}









