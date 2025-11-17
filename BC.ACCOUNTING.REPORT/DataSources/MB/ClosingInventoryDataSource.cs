namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class ClosingInventoryDataSource
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
