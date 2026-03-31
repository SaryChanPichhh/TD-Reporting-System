namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class ExpenseDataSource
    {
        public string ExpenseDesc { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string CurrencySymbol { get; set; } = "$";
    }
}
