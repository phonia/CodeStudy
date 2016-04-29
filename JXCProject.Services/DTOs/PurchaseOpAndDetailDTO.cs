using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXCProject.Services.DTOs
{
    public class PurchaseOpAndDetailDTO  
    {
        public string PurchaseOpId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal AppQty { get; set; }
        public decimal AprQty { get; set; }
        public string Appor { get; set; }
        public DateTime AppDate { get; set; }
        public DateTime Date { get; set; }
        public decimal? RecQty { get; set; }
        public decimal Amount { get; set; }
        public decimal StkPrice { get; set; }
        public string State { get; set; }
    }
}
