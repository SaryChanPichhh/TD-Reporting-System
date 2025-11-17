using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;
using DevExpress.Office.Utils;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESSaleInvoiceDto : ReportDto
    {
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public List<RESSaleInvoiceDataSource> Data { get; set; }
        public string ExchangeSign { get; set; } = "$";

    }
}
