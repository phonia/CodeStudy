//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JXCProject.Services.DTOs
{
    using System;
    using System.Collections.Generic;
    
    public partial class WarePositionDTO
    {
        public WarePositionDTO()
        {
            this.PositionStock = new HashSet<PositionStockDTO>();
            this.InStoreDetail = new HashSet<InStoreDetailDTO>();
        }
    
        public string ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string WareHouseId { get; set; }
    
        public virtual ICollection<PositionStockDTO> PositionStock { get; set; }
        public virtual WareHouseDTO WareHouse { get; set; }
        public virtual ICollection<InStoreDetailDTO> InStoreDetail { get; set; }
    }
}
