using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using JXCProject.Domain.Models;
using JXCProject.Repositories.ModelConfigurations;
using JXCProject.Domain;
using System.Data;

namespace JXCProject.Repositories
{
    public class JXCContext : DbContext, IQueryableUnitOfWork
    {
        public JXCContext()
            : base("JXCDatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<InStore> InStore { get; set; }
        public DbSet<InStoreDetail> InStoreDetail { get; set; }
        public DbSet<SaleOrder> SaleOrder { get; set; }
        public DbSet<SaleOrderDetail> SaleOrderDetail { get; set; }
        public DbSet<SaleOut> SaleOut { get; set; }
        public DbSet<SaleOutDetail> SaleOutDetail { get; set; }
        public DbSet<PurchaseOp> PurchaseOp { get; set; }
        public DbSet<PurchaseOpDetail> PurchaseOpDetail { get; set; }
        public DbSet<WareHouse> WareHouse { get; set; }
        public DbSet<WarePosition> WarePosition { get; set; }
        public DbSet<PositionStock> PositionStock { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CustomerAddressConfiguration());
            modelBuilder.Configurations.Add(new InStoreConfiguration());
            modelBuilder.Configurations.Add(new InStoreDetailConfiguration());
            modelBuilder.Configurations.Add(new SaleOrderConfiguration());
            modelBuilder.Configurations.Add(new SaleOrderDetailConfiguration());
            modelBuilder.Configurations.Add(new SaleOutConfiguration());
            modelBuilder.Configurations.Add(new SaleOutDetailConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new PurchaseOpConfiguration());
            modelBuilder.Configurations.Add(new PurchaseOpDetailConfiguration());
            modelBuilder.Configurations.Add(new WareHouseConfiguration());
            modelBuilder.Configurations.Add(new WarePositionConfiguration());
            modelBuilder.Configurations.Add(new PositionStockConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
        }

        public void Commite()
        {
            base.SaveChanges();
        }

        public void RollBackChanges()
        {
            base.ChangeTracker.Entries().ToList().ForEach(o => o.State = EntityState.Unchanged);
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Unchanged;
        }

        public void Modify<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Modify<TEntity>(TEntity originalEntity, TEntity newEntity) where TEntity:class
        {
            if (base.Entry<TEntity>(originalEntity).State != EntityState.Unchanged)
                base.Entry<TEntity>(originalEntity).State = EntityState.Unchanged;
            base.Entry<TEntity>(originalEntity).CurrentValues.SetValues(newEntity);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        public IDbSet<TEntity> GetSet<TEntity>() where TEntity:class 
        {
            return base.Set<TEntity>();
        }
    }
}
