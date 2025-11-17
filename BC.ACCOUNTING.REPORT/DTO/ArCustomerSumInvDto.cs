using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ArCustomerSumInvDto:ReportDto
    {
        [DisplayName("ក្រុមហ៊ុន")] public string? Company { get; set; }
        [DisplayName("កាលបរិច្ឆេទ")] public string Dates { get; set; }
        [DisplayName("វិក្កយបត្រ")] public List<ArCustomerSumInvDataSource> Invoices { get; set; }
        [DisplayName("អតិថិជនសរុប")] public string TotalCustomers { get; set; }
        [DisplayName("ចំនួនទូទាត់សរុប")] public string TotalAmount { get; set; }
        [DisplayName("ទឹកប្រាក់ជំពាក់សរុប")] public string TotalInDebt { get; set; }
    }
}
