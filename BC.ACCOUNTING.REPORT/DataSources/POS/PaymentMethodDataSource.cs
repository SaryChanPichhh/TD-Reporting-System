namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class PaymentMethodDataSource
    {
        public string PaymentType { get; set; }
        public string TotalRecieved { get; set; }
        public string CurrencySymbol { get; set; } = "$";
    }
}
