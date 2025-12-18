using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using BC.ACCOUNTING.REPORT.DataSources;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ArCustomerSummaryDto:ReportDto
    {
        [DisplayName("ក្រុមហ៊ុន")] public string Company { get; set; }
        [DisplayName("កាលបរិច្ឆេទ")] public string Dates { get; set; }
        [DisplayName("ទិន្នន័យ")] public List<ARCustomerSummaryDataSource> Items { get; set; }
        [DisplayName("សរុបបានអនុម័ត")] public string TotalApproved { get; set; }
        [DisplayName("សរុបកំពុងរង់ចាំ")] public string TotalPending { get; set; }
        [DisplayName("សរុបបានបដិសេធ")] public string TotalRejected { get; set; }
        [DisplayName("បង្កាន់ដៃសរុបទាំងអស់")] public string TotalReceipts { get; set; }
    }
}
