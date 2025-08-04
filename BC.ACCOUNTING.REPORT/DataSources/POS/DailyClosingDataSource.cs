namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class DailyClosingDataSource
    {
        public string Category { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

    }
}
