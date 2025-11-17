using System.Collections.Generic;
using System.Linq;
using System;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESSaleReceiptDto : ReportDto
    {
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        public string TransRef { get; set; }
        public DateTime TransDate { get; set; }
        public string Seller { get; set; }
        public string CustomerName { get; set; }
        public int? TableNo { get; init; }
        public List<int> TicketNos { get; set; } = new(); 
        public string? Note { get; set; }
        public string SubTotalType { get; set; }
        public string TotalDiscountType { get; set; }
        public string TotalAmountType { get; set; }
        public string SubTotalValue { get; set; }
        public string TotalDiscountValue { get; set; }
        public string TotalAccountValue { get; set; }
        public List<RESSaleReceiptDataSource> Items { get; set; }
        public string? ExchangeRate { get; set; }
        public string TicketNosDisplay => string.Join(", ", TicketNos ?? new List<int>());
       
    }
}
