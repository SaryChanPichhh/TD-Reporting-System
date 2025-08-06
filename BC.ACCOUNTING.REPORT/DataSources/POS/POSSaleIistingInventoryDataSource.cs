namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class POSSaleIistingInventoryDataSource
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int TotalPurchaseQty { get; set; } 
        public decimal TotalPurchaseCost { get; set; } 
        public int TotalSaleQty { get; set; } 
        public decimal TotalSaleCost { get; set; } 
        public int TotalRemainQty { get; set; } 
        public decimal TotalRemainCost { get; set; } 
    }
}