using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.Models
{
    public class RESFlatternPurchaseOrderRow
    {
        public string RowNumber { get; set; }        
        public string ItemCode { get; set; }        
        public string? ItemDesc { get; set; }
        public string ItemImage { get; set; }
        public decimal Qty { get; set; }            
        public string UnitStock { get; set; }       
        public decimal Price { get; set; }         
        public decimal Total { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
