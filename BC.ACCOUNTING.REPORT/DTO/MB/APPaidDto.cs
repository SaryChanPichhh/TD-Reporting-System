using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record APPaidDto : ReportDto
    {
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public List<APPaidDataSource> Items { get; set; }
    }
}
