using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record ClosingInventoryDto : ReportDto
    {
        public string Seller { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public decimal DiscountOnInvoice { get; set; }
        [DevExpress.Xpo.Nullable(true)]
        [Browsable(false)]
        public ExchangesCurrency? CurrencyCode { get; set; } = ExchangesCurrency.USD;
        public string CurrencySymbol => CurrencyCode.GetEnumDescription();
        public List<ClosingInventoryDataSource> Items { get; set; } 
    }
}
