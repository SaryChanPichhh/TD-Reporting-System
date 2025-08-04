using BC.ACCOUNTING.REPORT.DataSources;
using System;
using System.Collections.Generic;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record HD7SaleInvoiceDto:ReportDto
    {
        [DisplayName("លេខវិក័យប័ត្រ")] public string InvoiceNumber { get; set; }
        [DisplayName("ថ្ងៃចេញវិក័យប័ត្រ")] public DateTime? InvoiceDate { get; set; }
        [DisplayName("អ្នកចេញវិក័យប័ត្រ")] public string InvoicePrinted { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("លេខទូរសព្ទ")] public string Phone { get; set; }
        [DisplayName("អាស័យដ្ឋាន")] public string Address { get; set; }
        [DisplayName("សរុប")] public string Total { get; set; }
      
        [DisplayName("សម្គាល់")] public string Note { get; set; }
        public List<HD7SaleInvoiceDataSource> Items { get; set; }
    }
}
