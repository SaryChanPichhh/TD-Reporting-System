using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record InventoryExpiredDto​ : ReportDto
    {
        public DateTime PrintDate { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyImage { get; set; }
        public List<InventoryExpiredDataSource> Items { get; set; }
    }
}
