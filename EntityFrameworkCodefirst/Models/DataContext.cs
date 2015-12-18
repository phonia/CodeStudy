using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EntityFrameworkCodefirst.Models
{
    public class DataContext:DbContext
    {
        public DataContext()
            : base("name=DataContext")
        { }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public enum DepartmentNames
    {
        English,
        Math,
        Economics
    }

    [Table("Department")]
    public partial class Department
    {
        public int DepartmentID { get; set; }
        public DepartmentNames Name { get; set; }
        public decimal Budget { get; set; }
    }
}
