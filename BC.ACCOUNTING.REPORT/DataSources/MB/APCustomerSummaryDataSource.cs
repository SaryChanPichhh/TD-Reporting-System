namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class APCustomerSummaryDataSource
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Approved { get; set; }
        public string Pending { get; set; }
        public string Rejected { get; set; }
        public string Receipts { get; set; }
        public string? InvoiceIssuer { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        public string? PaymentMethod { get; set; } = string.Empty;
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        public DateTime? TransDate { get; set; } = DateTime.Now;
        public string TransRef { get; set; } = string.Empty;
    }
}
