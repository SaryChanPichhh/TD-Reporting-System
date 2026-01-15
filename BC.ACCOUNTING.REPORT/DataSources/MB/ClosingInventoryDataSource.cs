using System;
using System.Runtime.InteropServices.JavaScript;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class ClosingInventoryDataSource
    {
        public DateTime Date { get; set; }
        public string TransRef { get; set; }
        public decimal Total { get; set; }
        public string Seller { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal DiscountOnInvoice { get; set; }
        public string Unit { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public List<ExtraItemsDataSource> Extra { get; set; } = new();


    }
    public class ExtraItemsDataSource
    {
        public string ItemCode { get; set; }
        public string Unit { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal DiscountOnInvoice { get; set; }
        public decimal Total { get; set; }
    }
}
