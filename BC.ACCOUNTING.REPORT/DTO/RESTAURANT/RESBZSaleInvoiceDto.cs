using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESBZSaleInvoiceDto :ReportDto
    {
        public string TransRef { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string CustomerName { get; set; }
        public string RoomNumber { get; set; }
        public string Seller { get; set; }
        public decimal TotalDollar { get; set; }
        public decimal TotalRiel { get; set; }
        public List<RESBZSaleInvoiceDataSource> Items { get; set; }
    }
}
