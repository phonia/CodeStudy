using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 公司仓库
    /// </summary>
   public  class WareHouse:BaseEntity<string>
    {
       /// <summary>
       /// 名称
       /// </summary>
       public string Name { get; set; }
       /// <summary>
       /// 地址
       /// </summary>
       public string Address { get; set; }
       /// <summary>
       /// 邮编
       /// </summary>
       public string ZipCode { get; set; }
       /// <summary>
       /// 电话
       /// </summary>
       public string Telephone { get; set; }
       /// <summary>
       /// 联系人
       /// </summary>
       public string Linkman { get; set; }
       /// <summary>
       /// 操作人
       /// </summary>
       public string Opor { get; set; }
       /// <summary>
       /// 操作日期
       /// </summary>
       public DateTime OperDate { get; set; }
       /// <summary>
       /// 公司货位
       /// </summary>
       public IList<WarePosition> WarePostions { get; set; }
    }
}
