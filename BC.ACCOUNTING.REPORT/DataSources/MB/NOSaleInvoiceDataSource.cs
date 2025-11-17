using System.Collections.Generic;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class NOSaleInvoiceDataSource
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public double DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        
    }

}
