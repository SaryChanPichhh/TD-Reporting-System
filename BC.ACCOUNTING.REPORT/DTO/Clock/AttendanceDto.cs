using BC.ACCOUNTING.REPORT.DataSources.Clock;

namespace BC.ACCOUNTING.REPORT.DTO.Clock
{
    public record AttendanceDto : ReportDto
    {
        public DateTime PrintDate { get; set; } = DateTime.Today;
        public DateTime FromDate{ get; set; } = DateTime.Today;
        public DateTime ToDate { get; set; } = DateTime.Today;
        public List<AttendanceDataSource> Data { get; set; } = [];
    }

    public record AttendancePivotDto : ReportDto
    {
        public DateTime PrintDate { get; set; } = DateTime.Today;
        public DateTime FromDate { get; set; } = DateTime.Today;
        public DateTime ToDate { get; set; } = DateTime.Today;
        public List<AttendancePivotDataSource> Data { get; set; } = [];
    }
}
