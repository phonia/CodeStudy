using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 采购单
    /// </summary>
    public class PurchaseOp : BaseEntity<string>
    {
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount
        {
            get
            {
                decimal amount = decimal.Zero;
                foreach (var purchaseDetail in this.PurchaseOpDetails)
                {
                    if (purchaseDetail.AprQty == 0)
                        amount += purchaseDetail.AppQty * purchaseDetail.StkPrice;
                    else
                        amount += purchaseDetail.StkAmount;
                }
                return amount;
            }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string Appor { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime AppDate { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        public string Apror { get; set; }
        /// <summary>
        /// 审批日期
        /// </summary>
        public DateTime? AprDate { get; set; }
        /// <summary>
        /// 最近收货物日期
        /// </summary>
        public DateTime? LateRecDate { get; set; }
        /// <summary>
        /// 采购状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 采购单明细
        /// </summary>
        public virtual IList<PurchaseOpDetail> PurchaseOpDetails { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
