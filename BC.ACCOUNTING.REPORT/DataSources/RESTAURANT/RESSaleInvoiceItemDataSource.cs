using System;

namespace BC.ACCOUNTING.REPORT.DataSources.RESTAURANT
{
    public class RESSaleInvoiceItemDataSource
    {
        public string HeaderTransactionRef { get; set; }
        public DateTime TransDate { get; set; }
        public TimeOnly TransHour => TimeOnly.FromDateTime(TransDate);
        public DateOnly TransDay => DateOnly.FromDateTime(TransDate);
        public string Saller { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public decimal ItemCost { get; set; }
        public decimal Profit { get; set; }
    }
}
