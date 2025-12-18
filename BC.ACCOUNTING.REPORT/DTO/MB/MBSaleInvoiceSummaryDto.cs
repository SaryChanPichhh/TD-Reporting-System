using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record MBSaleInvoiceSummaryDto : ReportDto
    {
        public DateTime PrintDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SaleInvoiceSummaryDataSource> Items { get; set; }
    }
}
