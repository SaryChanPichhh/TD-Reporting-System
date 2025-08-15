using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ArCustomerSumInvDataSource
    {
        [DisplayName("វិក្កយបត្រ")] public string InvoiceNumber { get; set; }
        [DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("ឈ្មោះអ្នកលក់")] public string Seller { get; set; }
        [DisplayName("ថ្ងៃចេញវិក្កយប័ត្រ")] public DateTime InvoiceDate { get; set; }
        [DisplayName("ថ្ងៃត្រូវសង់")] public string DueDate { get; set; }
        [DisplayName("ទឹកប្រាក់")] public string TransValue { get; set; }
        [DisplayName("ទឹកប្រាក់ទូទាត់")] public string PaidValue { get; set; }
        [DisplayName("ទឹកប្រាក់ជំពាក់")] public string InDebt { get; set; }

    }
}
