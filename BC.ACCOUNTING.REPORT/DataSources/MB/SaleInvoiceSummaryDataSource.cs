using System;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class SaleInvoiceSummaryDataSource
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string TransRef { get; set; }
        public decimal ExchangeRate { get; set; } = 0;
        public string CustomerName { get; set; }
        public decimal TransValue { get; set; }
        public DateTime TransDate { get; set; }
    }
}
