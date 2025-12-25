using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO
{
    //[DisplayName("ទិន្នន័យស្តុកទំនិញ")]
    public record InventoryReportDto:ReportDto
    {
        [AllowNull ]
        public string? FIELD_1 { get; set; }
        [AllowNull]
        public string? FIELD_2 { get; set; }
        [AllowNull]
        public string? FIELD_3 { get; set; }
        [AllowNull]
        // For Visibility in Report Designer
        public string? FIELD_4 { get; set; }
        public List<InventoryReportDataSource> Items { get; set; }
    }
}
