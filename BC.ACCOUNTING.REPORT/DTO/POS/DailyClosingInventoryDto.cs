using BC.ACCOUNTING.REPORT.DataSources.POS;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record DailyClosingInventoryDto:ReportDto
    {
        [DisplayName("អ្នកលក់")] public string Seller { get; set; }
        [DisplayName("ថ្ងៃ")] public string Dates { get; set; }
        [DisplayName("ថ្ងៃព្រីន")] public DateTime PrintDate { get; set; }
        [DisplayName("រយពេល")] public string Duration { get; set; }
        [DisplayName("សរុបរង")] public decimal Subtotal { get; set; }
        [DisplayName("បញ្ចុះតម្លៃលើវិក្កយបត្រ")] public decimal Discount { get; set; }
        [DisplayName("សរុបវិក្កយបត្រ")] public string? TotalPrice { get; set; }
        [DisplayName("សរុបរៀល")] public decimal TotalRiel { get; set; }
        [DisplayName("សរុបដុល្លារ")] public decimal TotalDollar { get; set; }
        [DisplayName("ចំណាយ")] public decimal Expense { get; set; }
        [DisplayName("ចំណាយរៀល")] public decimal ExpenseRiel { get; set; }
        [DisplayName("អត្រាប្តូរប្រាក់")] public decimal ExchangeRate { get; set; } = 0;
        [DisplayName("ពន្ធ")] public decimal Vat { get; set; } = 0;
        [DisplayName("ប្រាក់អាប់")] public string CashChange { get; set; } = string.Empty;
        public List<ItemDataSource> Items { get; set; }  
        public List<PaymentMethodDataSource> Payments { get; set; }
        public List<ExpenseDataSource> Expenses { get; set; }
    }
}
