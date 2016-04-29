using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXCProject.BLL.DTO
{
   public  class DepartmentDTO
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
    }
}
