namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class NODailySaleDataSource
    {
        public string ITEM_CODE { get; set; }
        public string ITEM_DESC { get; set; }
        public decimal ITEM_PRICE1 { get; set; }
        public int TOTAL_QUANTITY { get; set; }
        public decimal TOTAL_REVENUE { get; set; }
        public decimal TOTAL_DISCOUNT { get; set; }
        public decimal TOTAL_COST { get; set; }
        public decimal TOTAL_PROFIT { get; set; }
    }

    public class NOExtraDailySaleDataSource : NODailySaleDataSource
    {
        
    }
}
