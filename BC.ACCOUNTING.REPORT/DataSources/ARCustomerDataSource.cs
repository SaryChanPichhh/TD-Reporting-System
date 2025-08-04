using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ARCustomerDataSource
    {
        [DisplayName("វិក្កយបត្រ")] public string InvoiceNumber { get; set; }
        [DisplayName("ថ្ងៃទូទាត់")] public DateTime PaymentDate { get; set; }
        [DisplayName("ទឹកប្រាក់")] public string TransValue { get; set; }
        [DisplayName("ចំនួនទូទាត់")] public string Amount { get; set; }
    }
}
