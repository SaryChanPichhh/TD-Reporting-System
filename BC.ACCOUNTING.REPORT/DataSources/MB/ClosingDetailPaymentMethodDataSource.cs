namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class ClosingDetailPaymentMethodDataSource
    {
        public string PaymentType { get; set; }
        public string TotalRecieved { get; set; }
        public string CurrencySymbol { get; set; } = "$";
    }
}
