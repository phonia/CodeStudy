using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee : BaseEntity<Guid>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Required]
        public string IDCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 名族
        /// </summary>
        public string Race { get; set; }
        public string BloodType { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Degree { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string Bank { get; set; }
        /// <summary>
        /// 开户账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime EmployeDate { get; set; }
        /// <summary>
        /// 离职时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DismissDate { get; set; }
        /// <summary>
        /// 员工类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 登录名称
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// 销售单明细
        /// </summary>
        public virtual IList<SaleOrderDetail> SaleOrderDetails { get; set; }
    }
}
