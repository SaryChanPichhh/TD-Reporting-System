using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record NOSaleInvoiceDto : ReportDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? InvoicePrinted { get; set; } = DateTime.Today;
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTel1 { get; set; }
        public string CustomerTel2 { get; set; }
        public decimal ExchangeRate { get; set; } = 0;
        [Browsable(false)]
        public List<string> Tables { get; set; } = [];
        [Browsable(false)]
        public List<string> Queues { get; set; } = [];
        public decimal DiscountOnInvoice { get; set; }
        public decimal TotalUSD { get; set; }
        public decimal TotalKHR { get; set; }
        public string Note { get; set; }
        public string Seller { get; set; }
        public decimal Deposit { get; set; }
        public decimal DiscountPercentOnInvoice { get; set; }
        [Nullable(true)]
        [Browsable(false)]
        public int IsCombo { get; set; } = 0;
        public bool ShowCombo => IsCombo.FromIntegerToBoolean();
        public List<InvoiceItemDataSource> Items { get; set; } = new();
        public string TablesDisplay => string.Join(", ", Tables);
        public string QueuesDisplay => string.Join(", ", Queues);
        [Nullable(true)]
        public NoAddressInfoModel? Info { get; set; } = new();
        public List<PaymentDataSource> Payments { get; set; } = [];
        public decimal TotalReceived { get; set; } = 0;
        public decimal TotalReceivedRiel { get; set; } = 0;
        public decimal TotalChange { get; set; } = 0;
        public decimal TotalChangeRiel { get; set; } = 0;
        public string PaymentMethod { get; set; } = string.Empty;
        [Nullable(true)]
        [Browsable(false)]
        public InvoiceStatus InvoiceStatus { get; set; } = InvoiceStatus.PAID;
        public DateTime PaidDate { get; set; } = DateTime.Today;
    }

    public class NoAddressInfoModel
    {
        public string BranchId { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string BranchName_KH { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string QrCode { get; set; } = string.Empty;
        public string Address_KH { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone_1 { get; set; } = string.Empty;
        public string Phone_2 { get; set; } = string.Empty;

    }

    public class PaymentDataSource
    {
        public string PaymentType { get; set; } = string.Empty;
        public decimal TotalRecieved { get; set; } = 0;
        public string CurrencySymbol { get; set; } = "$";
    }
}

