using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using ExpenseDataSource = BC.ACCOUNTING.REPORT.DataSources.MB.ExpenseDataSource;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record ClosingInventoryDto : ReportDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalDiscountOnInvoice { get; set; }
        public decimal TotalDiscountOnItem { get; set; }
        public decimal TotalChange { get; set; }
        public string Note { get; set; } = string.Empty;
        public List<string> Sellers { get; set; } = [];
        public decimal TotalReceived { get; set; } = 0;
        public decimal TotalReceivedRiel { get; set; } = 0;
        public List<ClosingInventoryDataSource> Items { get; set; }
        public List<PaymentMethodDataSource> Payments { get; set; }
        public List<ExpenseDataSource> Expenses { get; set; }
        public List<ExtraItemsDataSource>? Extras { get; set; } = [];
        public List<DeliveryPaymentDataSource>? Delivery { get; set; } = [];
        public NoAddressInfoModel? Info { get; set; } = new();

    }
}
