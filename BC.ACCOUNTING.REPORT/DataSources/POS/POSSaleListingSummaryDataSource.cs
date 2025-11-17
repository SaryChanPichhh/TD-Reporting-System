using System.Collections.Generic;
using System;

namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class POSSaleListingSummaryDataSource
    {
        public string Date { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Cost { get; set; }
        public decimal DeliveryFee { get; set; } = 0;
        public decimal Expense { get; set; }
        
    }
}
