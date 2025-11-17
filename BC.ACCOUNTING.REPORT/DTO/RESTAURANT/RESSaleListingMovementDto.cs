using System;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;
using System.Collections.Generic;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESSaleListingMovementDto : ReportDto
    {
        public List<RESSaleListingMovementDataSource> Items { get; set; }
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public string ExchangeSign { get; set; } = "$";
    }
}
