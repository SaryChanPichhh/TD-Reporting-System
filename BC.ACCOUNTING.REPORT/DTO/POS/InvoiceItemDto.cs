using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record InvoiceItemDto:ReportDto
    {
        public string CustomerName { get; set; }
        public string Dates { get; set; }
        public List<InvoiceItemDataSource> Items { get; set; }

    }
}
