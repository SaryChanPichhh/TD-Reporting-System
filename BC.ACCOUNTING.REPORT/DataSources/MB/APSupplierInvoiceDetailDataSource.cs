using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class APSupplierInvoiceDetailDataSource
    {
        public string SupplierCode { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<APSupplierInvoiceDataSource> Invoices { get; set; } = new();
    }
    public class APSupplierInvoiceDataSource
    {
        public string TransRef { get; set; } = string.Empty;
        public DateTime TransDate { get; set; } = DateTime.Today;
        public string DueDate { get; set; } =string.Empty;
        public string TransValue { get; set; } = string.Empty;
        public string PaidValue { get; set; } = string.Empty;
        public string InDebt { get; set; } = string.Empty;
        [Nullable(true)]
        public string InvoiceStatus { get; set; } = string.Empty;
        [Nullable(true)]
        public string InvoiceIssuer { get; set; } = string.Empty;
        [Nullable(true)]
        public string Note { get; set; } = string.Empty;
        [Nullable(true)]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
