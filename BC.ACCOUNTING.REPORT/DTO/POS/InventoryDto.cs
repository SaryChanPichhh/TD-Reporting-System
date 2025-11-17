using BC.ACCOUNTING.REPORT.DataSources.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record InventoryDto : ReportDto
    {
        public string? ShopName { get; set; }
        public string? ShopImage { get; set; }
        public DateTime PrintDate { get; set; }
        [Browsable(false)]
        [Nullable(true)]
        public Languages? Language { get; set; } = Languages.KM;
        public List<InventoryDataSource> Items { get; set; }

    }
}
