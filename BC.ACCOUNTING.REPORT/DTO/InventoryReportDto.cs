using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources;

namespace BC.ACCOUNTING.REPORT.DTO
{
    [DisplayName("ទិន្នន័យស្តុកទំនិញ")]
    public record InventoryReportDto:ReportDto
    {
        [DisplayName("ទិន្នន័យស្តុកទំនិញ")] public List<InventoryReportDataSource> Items { get; set; }
    }
}
