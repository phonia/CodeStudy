using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 入库货位
    /// </summary>
    public  class InStorePosition:IBaseEntity<Guid>
    {
        public Guid ID { get; set; }
        /// <summary>
        /// 入库量
        /// </summary>
        public decimal InQty { get; set; }
        /// <summary>
        /// 入库明细Id
        /// </summary>
        public Guid InStoreDetailId { get; set; }
        /// <summary>
        /// 公司货位Id
        /// </summary>
        public string WarePositionId { get; set; }
        /// <summary>
        /// 入库明细
        /// </summary>
        public InStoreDetail InStoreDetail { get; set; }
        /// <summary>
        ///公司货位
        /// </summary>
        public WarePosition WarePosition { get; set; }
    }
}
