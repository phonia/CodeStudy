using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 公司货位
    /// </summary>
    public class WarePosition : BaseEntity<string>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 公司仓库Id
        /// </summary>
        public string WareHouseId { get; set; }
        /// <summary>
        /// 公司仓库
        /// </summary>
        public WareHouse WareHouse { get; set; }
        /// <summary>
        /// 公司货位库存
        /// </summary>
        public IList<PositionStock> PositionStocks { get; set; }
        /// <summary>
        /// 入库明细
        /// </summary>
        public IList<InStoreDetail> InStoreDetails { get; set; }
    }
}
