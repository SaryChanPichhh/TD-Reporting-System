namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class InventoryDataSource
    {
        public string? Category { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int Stock { get; set; }
        public decimal? CostPrice { get; set; } 
        public decimal? ExchangeRate { get; set; }
    }
}
