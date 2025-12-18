using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using DevExpress.Office.Utils;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record CreditNoteDto : ReportDto
    {
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string SaleRep { get; set; }
        public string TransRef { get; set; }
        public string CreditTransRef { get; set; }
        [Nullable(true)]
        public decimal TotalDollar { get; set; } = 0;
        [Nullable(true)]
        public decimal TotalRiel { get; set; } = 0;
        [Nullable(true)]
        public decimal TotalMainCurrency { get; set; } = 0;
        [Nullable(true)]
        public decimal TotalSubCurrency { get; set; } = 0;
        [Nullable(true)]
        public decimal ExchangeRate { get; set; } = 0;
        public List<CreditNoteDataSource> Items { get; set; }
    }
    public class CreditNoteFlattenDto{
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string SaleRep { get; set; }
        public string TransRef { get; set; }
        public string CreditTransRef { get; set; }
        public decimal TotalDollar { get; set; }
        public decimal TotalRiel { get; set; }
        public decimal ExchangeRate { get; set; } = 0;
        public List<CreditNoteFlattenDataSource> Items { get; set; }
    }
}
