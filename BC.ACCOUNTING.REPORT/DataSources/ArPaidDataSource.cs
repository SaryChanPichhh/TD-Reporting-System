using BC.ACCOUNTING.REPORT.Models;
using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ArPaidDataSource
    {
        [DisplayName("ថ្ងៃទូទាត់")] public required DateTime PaidDate { get; set; }
        [DisplayName("វិក្កយបត្រ")] public string TransRef { get; set; }
        [DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("ទឹកប្រាក់")] public decimal TransValue { get; set; }
        [DisplayName("ចំនួនទូទាត់")] public decimal Amount { get; set; }
        [DisplayName("នៅសល់")] public decimal Balance { get; set; }
        [DisplayName("លេខទូរស័ព្ទ")] public string? PhoneNumber { get; set; }
        [DisplayName("អ្នកលក់")] public string? SaleRep { get; set; } = string.Empty;
        [DisplayName("អ្នកចេញវិក្កយបត្រ")] public string? InvoiceIssuer { get; set; } = string.Empty;
        [DisplayName("ពិពណ៏នា")] public string? Note { get; set; } = string.Empty;
        [DisplayName("ថ្ងៃទិញ")] public string? TransDate { get; set; } = string.Empty;


    }
}
