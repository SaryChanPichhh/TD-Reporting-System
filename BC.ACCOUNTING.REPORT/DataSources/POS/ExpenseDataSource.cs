namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class ExpenseDataSource
    {
        public string ExpenseDesc { get; set; }
        public string ExpenseBy { get; set; }
        public string ExpenseAmount { get; set; }
        public string CurrencySymbol { get; set; } = "$";
    }
}
