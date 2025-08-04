using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ArCustomerInvoiceDataSource
    {
        [DisplayName("វិក្កយបត្រ")] public string TransRef { get; set; }
        [DisplayName("ថ្ងៃចេញវិក្កយប័ត្រ")] public DateTime TransDate { get; set; }
        [DisplayName("ទឹកប្រាក់")] public string TransValue { get; set; }
        [DisplayName("ទឹកប្រាក់ជំពាក់")] public string InDebt { get; set; }
    }
}
