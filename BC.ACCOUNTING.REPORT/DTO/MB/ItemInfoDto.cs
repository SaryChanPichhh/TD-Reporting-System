using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record ItemInfoDto : ReportDto
    {
        public string CompanyName { get; set; }
        public List<ItemInfoDataSource> Items { get; set; }

    }
}
