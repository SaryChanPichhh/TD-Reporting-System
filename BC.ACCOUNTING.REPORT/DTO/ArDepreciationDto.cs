using BC.ACCOUNTING.REPORT.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ArDepreciationDto:ReportDto
    {
        [DisplayName("លេខវិក័យប័ត្រ")] public string InvoiceNumber { get; set; }
        [DisplayName("ថ្ងៃចេញវិក័យប័ត្រ")] public DateTime? InvoiceDate { get; set; }
        [DisplayName("ទឹកប្រាក់ជំពាក់សរុប")] public decimal TotalDueAmount { get; set; }
        [DisplayName("អ្នកលក់")] public string? Seller { get; set; }
        [DisplayName("អ្នកចេញវិក័យប័ត្រ")] public string? InvoiceIssuer { get; set; }
        [DisplayName("កូដអតិថិជន")] public string? CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("លេខទូរសព្ទ")] public string? Phone { get; set; }
        [DisplayName("អាស័យដ្ឋាន")] public string? Address { get; set; }
        [DisplayName("ផ្សារ")] public string? Market { get; set; }

        [DisplayName("ទិន្នន័យ")]  public List<ArDepreciationDataSource>? Items { get; set; }
    }
}
