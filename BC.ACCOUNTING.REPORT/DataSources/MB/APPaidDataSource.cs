namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class APPaidDataSource
    {
        public required DateTime PaidDate { get; set; }
        public string TransRef { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public decimal TransValue { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SaleRep { get; set; } = string.Empty;
        public string? InvoiceIssuer { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        public string? PaymentMethod { get; set; } = string.Empty;
        public DateTime? TransDate { get; set; } = DateTime.Now;
    }
}
