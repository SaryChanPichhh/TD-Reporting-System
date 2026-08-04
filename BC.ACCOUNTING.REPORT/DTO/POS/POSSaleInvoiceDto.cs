using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record POSSaleInvoiceDto : ReportDto
    {
        public POSSaleInvoiceDto()
        {
            Items = [];
        }
        public string ShopName { get; set; } = string.Empty;
        public string ShopImage { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string TransRef { get; set; } = string.Empty;
        public string TransDate { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string SubTotal { get; set; } = string.Empty;
        public string DiscountInvoice { get; set; } = string.Empty;
        public string TransValue { get; set; } = string.Empty;
        public string ExchangeRate { get; set; } = string.Empty;
        public string Vat { get; set; } = string.Empty;
        public string TransValueKH { get; set; } = string.Empty;
        public AmountReceive AmountReceive { get; set; } = new();
        [Nullable(true)] [Browsable(false)] public ReportModes? ReportMode { get; set; } = ReportModes.NormalMode;
        public decimal? DeliveryFee { get; set; } = 0;
        public string? Field1 { get; set; } = string.Empty;
        [Nullable(true)] public string? Field2 { get; set; } = string.Empty;
        public List<POSSaleInvoiceDataSource> Items { get; set; } = [];
        public List<Images>? Images { get; set; } = [];

        // printing preset
        [Browsable(false)]
        public bool ShowCashChange { get; set; } = false;
        [Browsable(false)]
        public bool ShowRowNum { get; set; } = false;
        [Browsable(false)]
        public bool ShowSubTotal { get; set; } = false;
        [Browsable(false)]
        public bool ShowDelivery { get; set; } = false;
    }

    public class Images
    {
        public string? ImageUrl { get; set; } = string.Empty;
    }
    public class AmountReceive
    {
        public string Amount { get; set; } = string.Empty;
        public string CurrencySymbol { get; set; } = string.Empty;
    }
}
