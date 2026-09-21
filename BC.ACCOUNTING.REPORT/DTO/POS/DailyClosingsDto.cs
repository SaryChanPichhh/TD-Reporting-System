using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record DailyClosingsDto : ReportDto
    {
        public string Dates { get; set; } = string.Empty;
        public DateTime PrintDate { get; set; } = DateTime.Today;
        public string Seller { get; set; } = string.Empty;
        public string TotalInvoice { get; set; } = string.Empty;
        public string PaidTotal { get; set; } = string.Empty;
        public string OwnedAmount { get; set; } = string.Empty;
        public string CashOB { get; set; } = string.Empty;
        public string CashOBRiel { get; set; } = string.Empty;
        public string Subtotal { get; set; } = string.Empty;
        public string Discount { get; set; } = string.Empty;
        public string TotalRiel { get; set; } = string.Empty;
        public string TotalDollar { get; set; } = string.Empty;
        public string CashIn { get; set; } = string.Empty;
        public string Remaining { get; set; } = string.Empty;
        [Nullable(true)]
        [Browsable(false)]
        [NullValue(true)]
        public Languages? Language { get; set; } =Languages.KM;
        public List<DailyClosingDataSource> Items { get; set; }
    }
}
