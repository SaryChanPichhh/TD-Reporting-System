using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESItemDto : ReportDto
    {
        public string? ShopImage { get; set; }
        public string? ShopName { get; set; }
        public DateTime? PrintDate { get; set; } = DateTime.Now;
        public List<RESItemDataSource> Items { get; set; }
    }
}
