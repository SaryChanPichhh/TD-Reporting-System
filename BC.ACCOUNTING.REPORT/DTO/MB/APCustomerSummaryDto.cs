using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record APCustomerSummaryDto : ReportDto
    {
        public string Company { get; set; }
        public string Dates { get; set; } 
        public List<APCustomerSummaryDataSource> Items { get; set; }
        public string TotalApproved { get; set; }
        public string TotalPending { get; set; }
        public string TotalRejected { get; set; }
        public string TotalReceipts { get; set; }
    }
}
