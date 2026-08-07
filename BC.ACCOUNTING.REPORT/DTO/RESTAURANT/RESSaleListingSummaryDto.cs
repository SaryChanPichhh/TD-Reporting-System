using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        [Browsable(false)] public Languages? Language { get; set; } = Languages.KM;
        [Browsable(false)] public ReportModes? ReportMode { get; set; } = ReportModes.NormalMode;
    }
}
