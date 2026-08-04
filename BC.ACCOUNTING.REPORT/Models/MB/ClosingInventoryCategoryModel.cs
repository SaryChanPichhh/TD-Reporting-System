using BC.ACCOUNTING.REPORT.DataSources.POS;

namespace BC.ACCOUNTING.REPORT.Models.MB
{
    public record ClosingInventoryCategoryModel : ReportDto
    {
        public string Seller { get; set; }
        public string Dates { get; set; }
        public DateTime PrintDate { get; set; }
        public string Duration { get; set; }
        public string Subtotal { get; set; }
        public string Discount { get; set; }
        public string? TotalPrice { get; set; }
        public decimal TotalRiel { get; set; }
        public decimal TotalDollar { get; set; }
        public string? Expense { get; set; }
        public string? ExpenseRiel { get; set; }
        public string? ExchangeRate { get; set; }
        public string? Vat { get; set; }
        public string? CashChange { get; set; }
        public List<ItemDataSource> Items { get; set; } = [];
        public List<DailyClosingPaymentDataSource> Payments { get; set; } = [];
        public List<ExpenseDataSource> Expenses { get; set; } = [];
    }
}
