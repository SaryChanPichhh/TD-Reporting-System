using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using DevExpress.Office.Utils;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record POSItemDto : ReportDto
    {
        public string? ShopImage { get; set; }
        public string? ShopName { get; set; }
        [Nullable(true)]
        [Browsable(false)]
        public Languages? Language { get; set; } = Languages.KM;
        public DateTime? PrintDate { get; set; } = DateTime.Now;
        public List<POSItemDataSource> Items { get; set; }
    }
}
