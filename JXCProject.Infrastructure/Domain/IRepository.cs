using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using JXCProject.Infrastructure.UnitOfWork;

namespace JXCProject.Infrastructure.Domain
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class ,IEntity
    {
        IUnitOfWork UnitOfWork { get; }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        void Modify(TEntity entity);
        /// <summary>
        /// 实体部分更新
        /// </summary>
        /// <param name="originalEntity">原实体</param>
        /// <param name="newEntity">新实体</param>
        void Modify(TEntity originalEntity, TEntity newEntity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
        /// <summary>
        /// 设置实体为UnChanged状态
        /// </summary>
        /// <param name="entity"></param>
        void TrackItem(TEntity entity);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// 根据Id查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById<T>(T id);
        /// <summary>
        /// 获取排序分页后的实体集
        /// </summary>
        /// <typeparam name="TProperty">排序的属性</typeparam>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageCount">页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">是否升序</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);
        /// <summary>
        /// 获取排序分页后的实体集
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageCount">页记录数</param>
        /// <param name="orderText">排序的字段名称</param>
        /// <param name="ascending">是否升序</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(int pageIndex, int pageCount, string orderText, bool ascending);
        /// <summary>
        /// 根据where条件获取实体集
        /// </summary>
        /// <param name="expression">where条件</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetByWhere(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// 根据where条件获取排序分页后的实体集
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageCount">页记录数</param>
        /// <param name="expression">where条件</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">是否升序</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);
        /// <summary>
        ///  根据where条件获取排序分页后的实体集
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageCount">页记录数</param>
        /// <param name="epxression">where条件</param>
        /// <param name="orderText">排序的字段名称</param>
        /// <param name="ascending">排序表达式</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(int pageIndex, int pageCount, Expression<Func<TEntity, bool>> epxression, string orderText, bool ascending);
        /// <summary>
        /// 根据多Where条件获取实体集
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="hasManyWhereCondition">true</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetByWhere(Expression<Func<TEntity, bool>> expression,bool hasManyWhereCondition);
        /// <summary>
        /// 根据多Where条件获取排序分页后的实体集
        /// </summary>
        /// <typeparam name="TProperty">排序的属性</typeparam>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageCount">页记录数</param>
        /// <param name="expression">表达式</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">是否升序</param>
        /// <param name="hasManyWhereCondition">true</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TProperty>(int pageIndex, int pageCount,Expression<Func<TEntity, bool>> expression, Func<TEntity, TProperty> orderByExpression, bool ascending, bool hasManyWhereCondition);
        /// <summary>
        /// 根据多Where条件获取排序分页后的实体集
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageCount">页记录数</param>
        /// <param name="expression">表达式</param>
        /// <param name="orderText">排序的字段名称</param>
        /// <param name="ascending">是否升序</param>
        /// <param name="hasManyWhereCondition">true</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(int pageIndex, int pageCount, Expression<Func<TEntity, bool>> expression,string orderText, bool ascending, bool hasManyWhereCondition);
    }
}
