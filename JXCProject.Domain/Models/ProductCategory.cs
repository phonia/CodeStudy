using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 品种分类
    /// </summary>
    public class ProductCategory : BaseEntity<string>
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public virtual IList<Product> Products { get; set; }
    }
}
