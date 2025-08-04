using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.POS;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record InvoiceItemDto:ReportDto
    {
        public string CustomerName { get; set; }
        public string Dates { get; set; }

        public List<InvoiceItemDataSource> Items { get; set; }

    }
}
