using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESSaleListingInvoiceDto : ReportDto
    {
        public string ShopImage { get; set; }
        public string ShopName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        [Browsable(false)] public Languages? Language { get; set; } = Languages.KM;
        [Browsable(false)] public ReportModes? ReportMode { get; set; } = ReportModes.NormalMode;
        public List<RESSaleInvoiceItemDataSource> SaleInvoice { get; set; }

    }
}
