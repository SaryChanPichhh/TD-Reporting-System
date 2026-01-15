namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class POSPOListingDataSource
    {
        public DateTime ReceiveDate { get; set; }
        public List<POSPOList> Items { get; set; }
    }
    public class POSPOList
    {
        public string Time { get; set; }
        public string Warehouse { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNameKH { get; set; }
        public string TransRef { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string? ItemDescKH { get; set; }
        public int Qty { get; set; }
        public decimal Cost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal ExchangeRate { get; set; } = 1;
    }
}
