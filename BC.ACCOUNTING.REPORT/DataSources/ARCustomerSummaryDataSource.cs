using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ARCustomerSummaryDataSource
    {
        [DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("ទឹកប្រាក់អនុម័ត")] public string Approved { get; set; }
        [DisplayName("ទឹកប្រាក់កំពុងរង់ចាំ")] public string Pending { get; set; }
        [DisplayName("ទឹកប្រាក់បដិសេធ")] public string Rejected { get; set; }
        [DisplayName("បង្កាន់ដៃសរុប")] public string Receipts { get; set; }
        [DisplayName("អ្នកលក់")] public string? SaleRep { get; set; } = string.Empty;
        [DisplayName("អ្នកចេញវិក្កយបត្រ")] public string? InvoiceIssuer { get; set; } = string.Empty;
        [DisplayName("ពិពណ៏នា")] public string? Note { get; set; } = string.Empty;
        [DisplayName("វិធីសាស្ត្របង់ប្រាក់")] public string? PaymentMethod { get; set; } = string.Empty;
        [DisplayName("ថ្ងៃទូទាត់")] public DateTime?  PaymentDate{ get; set; } = DateTime.Now;
        [DisplayName("ថ្ងៃទិញ")] public DateTime? TransDate { get; set; } = DateTime.Now;
        public string  TransRef { get; set; } = string.Empty;
    }
}
