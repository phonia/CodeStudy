using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using JXCProject.Infrastructure.UnitOfWork;
using JXCProject.Infrastructure.Domain;
using JXCProject.Infrastructure.Extesions;

namespace JXCProject.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class ,IEntity
    {
        private IQueryableUnitOfWork unitOfWork;

        protected Repository(IQueryableUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual IUnitOfWork UnitOfWork
        {
            get { return this.unitOfWork; }
        }

        public virtual void Add(TEntity entity)
        {
            GetSet().Add(entity);
        }

        public virtual void Modify(TEntity entity)
        {
            unitOfWork.Modify<TEntity>(entity);
        }

        public virtual void Modify(TEntity originalEntity, TEntity newEntity)
        {
            unitOfWork.Modify(originalEntity, newEntity);
        }

        public virtual void Remove(TEntity entity)
        {
            unitOfWork.Attach<TEntity>(entity);
            GetSet().Remove(entity);
        }

        public virtual void TrackItem(TEntity entity)
        {
            unitOfWork.Attach<TEntity>(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }

        public virtual TEntity GetById<T>(T id)
        {
            return GetSet().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll<TProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            if (ascending)
                return GetSet().OrderBy(orderByExpression).Take(pageCount * pageIndex).Skip(pageIndex);
            else
                return GetSet().OrderByDescending(orderByExpression).Take(pageCount * pageIndex).Skip(pageIndex);
        }

        public virtual IEnumerable<TEntity> GetAll(int pageIndex, int pageCount, string orderText, bool ascending)
        {
            if (string.IsNullOrEmpty(orderText))
                return GetSet().Skip(pageCount * pageIndex).Take(pageCount);
            else
                return GetSet().DynamicOrderBy(orderText, ascending).Skip(pageCount * pageIndex).Take(pageCount);
        }

        public virtual IEnumerable<TEntity> GetByWhere(Expression<Func<TEntity, bool>> expression)
        {

            return GetSet().Where(expression);
        }

        public virtual IEnumerable<TEntity> GetAll<TProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            if (ascending)
                return GetSet().Where(expression).OrderBy(orderByExpression).Take(pageCount * pageIndex).Skip(pageIndex);
            else
                return GetSet().Where(expression).OrderByDescending(orderByExpression).Take(pageCount * pageIndex).Skip(pageIndex);
        }

        public virtual IEnumerable<TEntity> GetAll(int pageIndex, int pageCount, Expression<Func<TEntity, bool>> expression, string orderText, bool ascending)
        {
            if (string.IsNullOrEmpty(orderText))
                return GetSet().Where(expression).Skip(pageCount * pageIndex).Take(pageCount);
            else
                return GetSet().Where(expression).DynamicOrderBy(orderText, ascending).Skip(pageCount * pageIndex).Take(pageCount);
        }

        public virtual IEnumerable<TEntity> GetByWhere(Expression<Func<TEntity, bool>> expression, bool hasManyWhereCondition)
        {
            return GetSet().Wheres(expression);
        }

        public virtual IEnumerable<TEntity> GetAll<TProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, bool>> expression, Func<TEntity, TProperty> orderByExpression, bool ascending, bool hasManyWhereCondition)
        {
            if (ascending)
                return GetSet().Wheres(expression).OrderBy(orderByExpression).Skip(pageCount * pageIndex).Take(pageCount);
            else
                return GetSet().Wheres(expression).OrderByDescending(orderByExpression).Skip(pageCount * pageIndex).Take(pageCount);
        }

        public virtual IEnumerable<TEntity> GetAll(int pageIndex, int pageCount, Expression<Func<TEntity, bool>> expression, string orderText, bool ascending, bool hasManyCondition)
        {
            if (string.IsNullOrEmpty(orderText))
                return GetSet().Wheres(expression).Skip(pageCount * pageIndex).Take(pageCount);
            else
                return GetSet().Wheres(expression).DynamicOrderBy(orderText, ascending).Skip(pageCount * pageIndex).Take(pageCount);
        }

        public void Dispose()
        {
            if (unitOfWork != null)
                unitOfWork.Dispose();
        }

        private IDbSet<TEntity> GetSet()
        {
            return unitOfWork.GetSet<TEntity>();
        }
    }
}
