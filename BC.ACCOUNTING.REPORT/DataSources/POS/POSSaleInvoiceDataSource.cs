namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
        public class POSSaleInvoiceDataSource
        {
            public string ItemCode { get; set; }
            public string ItemDesc { get; set; }
            public int Qty { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Discount { get; set; }
            public decimal TotalPrice { get; set; }
            
        }
}
