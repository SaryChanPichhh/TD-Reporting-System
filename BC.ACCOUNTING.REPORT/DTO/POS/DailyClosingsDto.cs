using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.POS;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record DailyClosingsDto : ReportDto
    {
        public string Dates { get; set; }
        public DateTime PrintDate { get; set; }
        public string Seller { get; set; }
        public string TotalInvoice { get; set; }
        public string PaidTotal { get; set; }
        public string OwnedAmount { get; set; }
        public string CashOB { get; set; }
        public string CashOBRiel { get; set; }

        public string Subtotal { get; set; }
        public string Discount { get; set; }
        public string TotalRiel { get; set; }
        public string TotalDollar { get; set; }
        public string CashIn { get; set; }
        public string Remaining { get; set; }

        public List<DailyClosingDataSource> Items { get; set; }
    }
}
