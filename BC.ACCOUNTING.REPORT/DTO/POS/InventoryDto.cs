using BC.ACCOUNTING.REPORT.DataSources.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Xpo;
using BC.ACCOUNTING.REPORT.Helper.Enums;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record InventoryDto : ReportDto
    {
        public string? ShopName { get; set; }
        public string? ShopImage { get; set; }
        public DateTime PrintDate { get; set; }
        [Browsable(false)] [Nullable(true)] public bool IsShowCost { get; set; } = true;
        [Browsable(false)] [Nullable(true)] public bool IsShowSalePrice { get; set; } = false;
        public List<InventoryDataSource> Items { get; set; }

    }
}
