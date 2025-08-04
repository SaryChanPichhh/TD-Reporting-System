using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ArCustomerDto:ReportDto
    {
        [DisplayName("ក្រុមហ៊ុន")] public string Company { get; set; }
        [DisplayName("កាលបរិច្ឆេទ")] public string Dates { get; set; }
        [DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("លេខទូរសព្ទ")] public string Phone { get; set; }
        [DisplayName("អាស័យដ្ឋាន")] public string Address { get; set; }
        [DisplayName("ផ្សារ")] public string Market { get; set; }
        [DisplayName("តូប")] public string Store { get; set; }
        [DisplayName("អ្នកចេញវិក្កយប័ត្រ")] public string Issuer { get; set; }
        [DisplayName("ទឹកប្រាក់ជំពាក់")] public string InDebt { get; set; }
        [DisplayName("ថ្ងៃចេញវិក្កយប័ត្រ")] public DateTime InvoiceDate { get; set; }

        [DisplayName("បង្កាន់ដៃកំពុងរង់ចាំ")] public List<ARCustomerDataSource> PendingReceipts { get; set; }
        [DisplayName("បង្កាន់ដៃបានអនុម័ត")] public List<ARCustomerDataSource> ApprovedReceipts { get; set; }
        [DisplayName("បង្កាន់ដៃបានបដិសេធ")] public List<ARCustomerDataSource> RejectedReceipts { get; set; }

        [DisplayName("សរុបបានអនុម័ត")] public string TotalApproved { get; set; }
        [DisplayName("សរុបកំពុងរង់ចាំ")] public string TotalPending { get; set; }
        [DisplayName("សរុបបានបដិសេធ")] public string TotalRejected { get; set; }
    }
}
