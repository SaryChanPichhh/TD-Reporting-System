using BC.ACCOUNTING.REPORT.DataSources.POS;

namespace BC.ACCOUNTING.REPORT.DataSources.RESTAURANT
{
    public class RESSaleListingMovementDataSource 
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int TotalPurchaseQty { get; set; }
        public decimal TotalPurchaseCost { get; set; }
        public int TotalSaleQty { get; set; }
        public decimal TotalSaleCost { get; set; }
        public int TotalRemainQty { get; set; }
        public decimal TotalRemainCost { get; set; }
        public int TotalOldOBQty { get; set; }
        public decimal TotalOldOBCost { get; set; }
        
    }
}
