namespace BC.ACCOUNTING.REPORT.DataSources.RESTAURANT
{
    public class RESBZSaleInvoiceDataSource
    {
        public string ItemDesc { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
