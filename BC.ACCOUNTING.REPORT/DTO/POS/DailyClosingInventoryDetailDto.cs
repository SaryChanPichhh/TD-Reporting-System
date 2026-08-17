using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using DevExpress.Xpo;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO.POS;

public record DailyClosingInventoryDetailDto : ReportDto
{
    public DateTime PrintDate { get; set; }
    public string Expense { get; set; } = string.Empty;
    public string ExpenseRiel { get; set; } = string.Empty;
    public string ExchangeRate { get; set; } = string.Empty;
    public string Vat { get; set; } = string.Empty;
    public string CashChange { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public decimal DiscountInvoice { get; set; }
    public decimal TotalAmountRiel { get; set; } = 0;
    public decimal TotalAmountDollar { get; set; } = 0;
    public string Subtotal { get; set; } = string.Empty;
    public string TotalRiel { get; set; } = string.Empty;
    public string TotalDollar { get; set; } = string.Empty;
    public bool IsFiltering { get; set; } = false;
    [Nullable(true)][Browsable(false)] public Languages? Language { get; set; } = Languages.KM;
    public List<DailyClosingDetailDataSource> DailyClosings { get; set; } = [];
}