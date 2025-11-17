using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record POSSaleListingReportDto : ReportDto
    {   
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        public string TotalRiel { get; set; }
        public string TotalDollar { get; set; }
        [Nullable(true)]
        [Browsable(false)] public Languages? Language { get; set; } = Languages.KM;
        public List<PaymentMethodDataSource> Payments { get; set; }
        public List<POSSaleListingDataSource> Data { get; set; }
    }

}
