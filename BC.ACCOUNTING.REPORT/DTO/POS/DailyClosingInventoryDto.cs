using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record DailyClosingInventoryDto:ReportDto
    {
        [DevExpress.Xpo.DisplayName("អ្នកលក់")] public string Seller { get; set; }
        [DevExpress.Xpo.DisplayName("ថ្ងៃ")] public string Dates { get; set; }
        [DevExpress.Xpo.DisplayName("ថ្ងៃព្រីន")] public DateTime PrintDate { get; set; }
        [DevExpress.Xpo.DisplayName("រយពេល")] public string Duration { get; set; }
        [DevExpress.Xpo.DisplayName("សរុបរង")] public string Subtotal { get; set; }
        [DevExpress.Xpo.DisplayName("បញ្ចុះតម្លៃលើវិក្កយបត្រ")] public string Discount { get; set; }
        [DevExpress.Xpo.DisplayName("សរុបវិក្កយបត្រ")] public string? TotalPrice { get; set; }
        [DevExpress.Xpo.DisplayName("សរុបរៀល")] public string TotalRiel { get; set; }
        [DevExpress.Xpo.DisplayName("សរុបដុល្លារ")] public string TotalDollar { get; set; }
        [DevExpress.Xpo.DisplayName("ចំណាយ")] public string Expense { get; set; }
        [DevExpress.Xpo.DisplayName("ចំណាយរៀល")] public string ExpenseRiel { get; set; }
        [DevExpress.Xpo.DisplayName("អត្រាប្តូរប្រាក់")] public string ExchangeRate { get; set; }
        [DevExpress.Xpo.DisplayName("ពន្ធ")] public string Vat { get; set; }
        [DevExpress.Xpo.DisplayName("ប្រាក់អាប់")] public string CashChange { get; set; }
        [Nullable(true)]
        [Browsable(false)]
        public Languages? Language { get; set; } = Languages.KM;
        [Browsable(false)] public ReportModes? ReportMode { get; set; } = ReportModes.NormalMode;
        public List<ItemDataSource> Items { get; set; }  
        public List<PaymentMethodDataSource> Payments { get; set; }
    }
}
