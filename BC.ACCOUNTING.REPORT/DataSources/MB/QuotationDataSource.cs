namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class QuotationDataSource
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public string UnitStock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
