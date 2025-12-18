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
            public string ShopName { get; set; }
            public string ShopImage { get; set; }
            public string CustomerName { get; set; }
            public string TransRef { get; set; }
            public string TransDate { get; set; }
            public string SubTotal { get; set; }
            public string DiscountInvoice { get; set; }
            public string TransValue { get; set; }
            public string ExchangeRate { get; set; }
            public string TransValueKH { get; set; }
            public string Note { get; set; }
            [Nullable(true)] [Browsable(false)] public Languages? Language { get; set; } = Languages.KM;
            [Nullable(true)] [Browsable(false)] public ReportModes? ReportMode { get; set; } = ReportModes.NormalMode;
            
            public decimal? DeliveryFee { get; set; } = 0;
            public string? Field1 { get; set; }
            [Nullable(true)] public string? Field2 { get; set; }
            public List<POSSaleInvoiceDataSource> Items { get; set; }
        }
}
