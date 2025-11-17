using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record NOSaleInvoiceDto : ReportDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime InvoicePrinted { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTel1 { get; set; }
        public string CustomerTel2 { get; set; }
        [Browsable(false)]
        public List<string> Tables { get; set; } = new();
        [Browsable(false)]
        public List<string> Queues { get; set; } = new();
        public decimal Discount { get; set; }
        public decimal TotalUSD { get; set; }
        public decimal TotalKHR { get; set; }
        public string Note { get; set; }
        public string Seller { get; set; }
        public decimal Deposit { get; set; }
        public decimal DiscountPercent { get; set; }
        [Nullable(true)]
        [Browsable(false)]
        public ExchangesCurrency? CurrencyCode { get; set; } = ExchangesCurrency.USD;
        public string CurrencySymbol => CurrencyCode.GetEnumDescription();
        [Nullable(true)]
        [Browsable(false)]
        public int IsCombo { get; set; } = 0;
        public bool ShowCombo => IsCombo.FromIntegerToBoolean();
        public List<InvoiceItemDataSource> Items { get; set; } = new();
        public string TablesDisplay => string.Join(", ", Tables);
        public string QueuesDisplay => string.Join(", ", Queues);
    }
}

