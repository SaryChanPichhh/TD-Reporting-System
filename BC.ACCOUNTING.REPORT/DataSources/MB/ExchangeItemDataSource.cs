namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class ExchangeItemDataSource
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UnitStock { get; set; }
        public int Unit { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Total { get; set; }
    }
}
