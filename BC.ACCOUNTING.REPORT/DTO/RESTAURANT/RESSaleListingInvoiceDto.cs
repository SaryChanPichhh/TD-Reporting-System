using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;
using System;
using System.Collections.Generic;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESSaleListingInvoiceDto : ReportDto
    {
        public string ShopImage { get; set; }
        public string ShopName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public List<RESSaleInvoiceItemDataSource> SaleInvoice { get; set; }

    }
}
