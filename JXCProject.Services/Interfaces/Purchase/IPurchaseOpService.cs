using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.DTOs;

namespace JXCProject.Services.Interfaces.Purchase
{
    public interface IPurchaseOpService
    {
        /// <summary>
        /// 采购单申请
        /// </summary>
        /// <param name="purchase">采购单</param>
        void PurchaseApply(PurchaseOpDTO purchase);
        /// <summary>
        /// 采购单审批
        /// </summary>
        /// <param name="pruchase">采购单</param>
        void PurchaseApprove(PurchaseOpDTO pruchase);
        /// <summary>
        /// 采购单修改
        /// </summary>
        /// <param name="purchase">采购单</param>
        void ModifyPurchase(PurchaseOpDTO purchase);
        /// <summary>
        /// 删除采购单
        /// </summary>
        /// <param name="purchase">采购单</param>
        void RemovePurchase(PurchaseOpAndDetailDTO purchase);
        /// <summary>
        /// 获取采购客户信息(供应商)
        /// </summary>
        /// <param name="cstName">客户姓名</param>
        /// <returns></returns>
        IEnumerable<CustomerDTO> GetPurchaseCustomerByName(string cstName);
        /// <summary>
        /// 根据品种分类和品种名称获取品种信息
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<ProductDTO> GetProductByCategoryIdAndName(string categoryId, string name);
        /// <summary>
        /// 根据采购单号获取需要审批的采购单
        /// </summary>
        /// <param name="purchaseOpId">采购单号</param>
        /// <returns></returns>
        IEnumerable<PurchaseOpAndDetailDTO> GetForApprovedPurchaseOp(string purchaseOpId);
        /// <summary>
        /// 根据采购单状态获取需要审批的采购单ID集合
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        IEnumerable<PurchaseOpAndDetailDTO> GetForApprovedPurchaseOpIds(string state);
        /// <summary>
        /// 根据采购单ID获取采购明细信息
        /// </summary>
        /// <param name="purchaseOpId"></param>
        /// <returns></returns>
        IEnumerable<PurchaseOpAndDetailDTO> GetPurchaseOpDetailById(string purchaseOpId);
        /// <summary>
        /// 查询采购单
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageCount">当前页数量</param>
        /// <param name="cstId">采购客户ID</param>
        /// <param name="productId">品种ID</param>
        /// <param name="startDate">采购日期</param>
        /// <param name="endDate">采购日期</param>
        /// <param name="orderText">排序字符</param>
        /// <param name="ascending">排序规则(升或降)</param>
        /// <param name="recordCount">记录数目</param>
        /// <returns></returns>
        IEnumerable<PurchaseOpAndDetailDTO> GetPageData(int pageIndex, int pageCount, string cstId, string productId, DateTime startDate, DateTime endDate, string orderText, bool ascending, out int recordCount);
    } 
}
