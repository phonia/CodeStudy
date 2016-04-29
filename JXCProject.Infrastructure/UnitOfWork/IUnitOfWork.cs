using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXCProject.Infrastructure.UnitOfWork 
{
    /// <summary>
    /// IUnitOfWork模式
    /// </summary>
    public  interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// 相当于Savechanges操作
        /// </summary>
        void Commite();
        /// <summary>
        /// 设置Changetracker中所有实体为UnChanged状态
        /// </summary>
        void RollBackChanges();
    }
}
