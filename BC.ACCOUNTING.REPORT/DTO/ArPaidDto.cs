using BC.ACCOUNTING.REPORT.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ArPaidDto:ReportDto
    {
        [DisplayName("ថ្ងៃចាប់ផ្តើម")] public required DateTime StartDate { get; set; }
        [DisplayName("ថ្ងៃបញ្ចប់")] public required DateTime EndDate { get; set; }
        [DisplayName("ទិន្នន័យ")] public List<ArPaidDataSource> Items { get; set; }

    }
}
