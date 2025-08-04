using BC.ACCOUNTING.REPORT.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ArCustomerInvoiceDto:ReportDto
    {
        [DisplayName("ក្រុមហ៊ុន")] public string Company { get; set; }
        [DisplayName("កាលបរិច្ឆេទ")] public string Dates { get; set; }
        [DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("លេខទូរសព្ទ")] public string Phone { get; set; }
        [DisplayName("អាស័យដ្ឋាន")] public string Address { get; set; }
        [DisplayName("ផ្សារ")] public string Market { get; set; }
        [DisplayName("តូប")] public string Store { get; set; }
        [DisplayName("វិក្កយបត្រ")] public List<ArCustomerInvoiceDataSource> Invoices { get; set; }
        [DisplayName("ចំនួនទូទាត់សរុប")] public string TotalAmount { get; set; }
        [DisplayName("ទឹកប្រាក់ជំពាក់សរុប")] public string TotalInDebt { get; set; }
    }
}
