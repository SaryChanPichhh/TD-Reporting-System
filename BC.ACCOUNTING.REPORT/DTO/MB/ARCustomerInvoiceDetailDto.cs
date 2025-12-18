using BC.ACCOUNTING.REPORT.DataSources;
using System.Collections.Generic;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record ARCustomerInvoiceDetailDto : ReportDto
    {
        public string Company { get; set; }
        public string PrintDate { get; set; }
        public string InvoicePrinter { get; set; } = string.Empty;
        public List<ARCustomerInvoiceDetailDataSource> Data { get; set; }
    }
    public class ARCustomerInvoiceDetailDataSource
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Market { get; set; }
        public string Store { get; set; }
        public List<ArCustomerInvoiceDataSource> Invoices { get; set; }
    }
}
