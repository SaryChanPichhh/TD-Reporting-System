using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record NODailySaleDto : ReportDto
    {
        public List<NODailySaleDataSource> Items { get; set; }
        public List<NOExtraDailySaleDataSource> Extra { get; set; } = [];
        public required DateTime start_date { get; set; }
        public required DateTime end_date { get; set; }
        public string shopName { get; set; }
        public string shopImage { get; set; }
    }
}
