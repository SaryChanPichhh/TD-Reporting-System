using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using System.ComponentModel;
using ItemDataSource = BC.ACCOUNTING.REPORT.DataSources.POS.ItemDataSource;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record DailyClosing80Dto : ReportDto
    {
        [DisplayName("អ្នកលក់")] public string Seller { get; set; }
        [DisplayName("ថ្ងៃ")] public string Dates { get; set; }
        [DisplayName("ថ្ងៃព្រីន")] public DateTime PrintDate { get; set; }
        [DisplayName("រយពេល")] public string Duration { get; set; }
        [DisplayName("សរុបរង")] public object Subtotal { get; set; }
        [DisplayName("បញ្ចុះតម្លៃលើវិក្កយបត្រ")] public object Discount { get; set; }
        [DisplayName("សរុបវិក្កយបត្រ")] public string? TotalPrice { get; set; }
        [DisplayName("សរុបរៀល")] public decimal TotalRiel { get; set; }
        [DisplayName("សរុបដុល្លារ")] public decimal TotalDollar { get; set; }
        [DisplayName("ចំណាយ")] public object? Expense { get; set; }
        [DisplayName("ចំណាយរៀល")] public object? ExpenseRiel { get; set; }
        [DisplayName("អត្រាប្តូរប្រាក់")] public object? ExchangeRate { get; set; } 
        [DisplayName("ពន្ធ")] public object? Vat { get; set; } 
        [DisplayName("ប្រាក់អាប់")] public object? CashChange { get; set; } 
        public List<DailyClosing80DataSource> Items { get; set; } = [];
        public List<DailyClosingPaymentDataSource> Payments { get; set; } = [];
        public List<ExpenseDataSource> Expenses { get; set; } = [];
    }
}
