namespace BC.ACCOUNTING.REPORT.DataSources.RESTAURANT
{
    public class RESSaleInvoiceDataSource
    {
        public string MenuCode { get; set; }
        public string Menu { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Cost { get; set; }
        public decimal ExchangeRate { get; set; } = 1;

    }
}
