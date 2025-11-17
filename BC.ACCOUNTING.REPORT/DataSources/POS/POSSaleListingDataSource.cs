using System;
using System.Collections.Generic;

namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class POSSaleListingDataSource
    {
        public DateOnly Date  { get; set; }
        public List<PaymentMethodDataSource> Payments { get; set; }
        public string SalePrice { get; set; }
        public string Discount { get; set; }
        public string Cost { get; set; }
        public string Expense { get; set; }
        public string NetPrice { get; set; }
        public string Profit { get; set; }
    }
}
