using BC.ACCOUNTING.REPORT.DataSources.Clock;

namespace BC.ACCOUNTING.REPORT.DTO.Clock
{
    public record OverTimeDto : ReportDto
    {
        public DateTime PrintDate { get; set; } = DateTime.Today;
        public List<OverTimeDataSource> Data { get; set; } = [];
    }

    public record OverTimePivotDto : ReportDto
    {
        public DateTime PrintDate { get; set; } = DateTime.Today;
        public List<OverTimePivotDataSource> Data { get; set; } = [];
    }
}
