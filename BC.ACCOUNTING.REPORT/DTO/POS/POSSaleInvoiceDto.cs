using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.POS;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record POSSaleInvoiceDto:ReportDto
    {
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        public string CustomerName { get; set; }
        public string TransRef { get; set; }
        public DateTime TransDate { get; set; }
        public string SubTotal { get; set; }
        public string DiscountInvoice { get; set; }
        public string TransValue { get; set; }
        public string ExchangeRate { get; set; }
        public string TransValueKH { get; set; }
        public string Note { get; set; }
        public List<POSSaleInvoiceDataSource> Items { get; set; }
    }
}
