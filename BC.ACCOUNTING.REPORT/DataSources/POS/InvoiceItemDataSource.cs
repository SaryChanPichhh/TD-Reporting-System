using System;

namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class InvoiceItemDataSource
    {
        public string TransRef { get; set; }
        public DateTime InvoicDate { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public decimal Price1 { get; set; }
        public int Qty { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountInvoice { get; set; }
    }
}
