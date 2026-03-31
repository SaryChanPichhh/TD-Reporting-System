namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class DeliveryPaymentDataSource
    {
        public string PaymentType { get; set; }
        public decimal TotalRecieved { get; set; }
        public string CurrencySymbol { get; set; } = "$";
    }
}

