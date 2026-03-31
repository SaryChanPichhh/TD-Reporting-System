using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources.POS;

public class DailyClosingDetailDataSource
{
    public string Seller { get; set; } = string.Empty;
    public string Dates { get; set; } = string.Empty;
    public List<ItemDataSource> Items { get; set; } = [];
    public List<PaymentMethodDataSource> Payments { get; set; } = [];
}