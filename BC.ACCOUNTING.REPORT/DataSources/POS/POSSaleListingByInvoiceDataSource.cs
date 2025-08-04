using System;

namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class POSSaleListingByInvoiceDataSource
    {
        public string TransRef { get; set; }
        public DateTime TransDate { get; set; }
        public TimeOnly TransHour => TimeOnly.FromDateTime(TransDate);
        public DateOnly TransDay => DateOnly.FromDateTime(TransDate);
        public string Seller { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public decimal Cost { get; set; }
        public decimal Profit { get; set; }
    }
}
