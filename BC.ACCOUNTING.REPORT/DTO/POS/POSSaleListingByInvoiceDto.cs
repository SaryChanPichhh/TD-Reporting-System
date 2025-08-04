using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.POS;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record POSSaleListingByInvoiceDto : ReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        public List<POSSaleListingByInvoiceDataSource> Items { get; set; }
    }
}
