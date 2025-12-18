using System;
using DevExpress.Xpo;
namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ArCustomerInvoiceDataSource
    {
        [DisplayName("វិក្កយបត្រ")] public string TransRef { get; set; }
        [DisplayName("ឈ្មោះអ្នកលក់")] public string Seller { get; set; }
        [DisplayName("ថ្ងៃចេញវិក្កយប័ត្រ")] public DateTime TransDate { get; set; }
        [DisplayName("ថ្ងៃត្រូវសង់")] public string DueDate { get; set; }
        [DisplayName("ទឹកប្រាក់")] public string TransValue { get; set; }
        [DisplayName("ទឹកប្រាក់ទូទាត់")] public string PaidValue { get; set; }
        [DisplayName("ទឹកប្រាក់ជំពាក់")] public string InDebt { get; set; }
        [Nullable(true)]
        public string InvoiceStatus { get; set; } = string.Empty;
        [Nullable(true)]
        public string InvoiceIssuer { get; set; } = string.Empty;
        [Nullable(true)]
        public string Note { get; set; } = string.Empty;
        [Nullable(true)]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
