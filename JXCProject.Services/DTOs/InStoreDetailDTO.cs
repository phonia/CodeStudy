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
    
    public partial class InStoreDetailDTO
    {
        public InStoreDetailDTO()
        {
            this.WarePosition = new HashSet<WarePositionDTO>();
        }
    
        public System.Guid ID { get; set; }
        public int Qty { get; set; }
        public System.DateTime ExpDate { get; set; }
        public string InStoreId { get; set; }
    
        public virtual InStoreDTO InStore { get; set; }
        public virtual ICollection<WarePositionDTO> WarePosition { get; set; }
    }
}
