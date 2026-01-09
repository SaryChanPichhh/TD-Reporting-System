using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record APSupplierInvoiceDetailDto : ReportDto
    {
        public string Company { get; set; } = string.Empty;
        public DateTime PrintDate { get; set; } = DateTime.Today;
        public string InvoicePrinter { get; set; } = string.Empty;
        public List<APSupplierInvoiceDetailDataSource> Data { get; set; }
    }

}
