using BC.ACCOUNTING.REPORT.DataSources.POS;
using System.Collections.Generic;
using System;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESSaleListingSummaryDto : ReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        public List<RESSaleListingSummaryDataSource> Data { get; set; }
        public string ExchangeSign { get; set; } = "$";
    }
}
