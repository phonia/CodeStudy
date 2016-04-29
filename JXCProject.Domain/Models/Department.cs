using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 部门
    /// </summary>
   public  class Department:BaseEntity<string>
    {
       /// <summary>
       /// 父级部门编号
       /// </summary>
       public string ParentID { get; set; }
       /// <summary>
       /// 名称
       /// </summary>
       public string Name { get; set; }
       /// <summary>
       /// 员工
       /// </summary>
       public virtual  IList<Employee> Employees { get; set; }
    }
}
