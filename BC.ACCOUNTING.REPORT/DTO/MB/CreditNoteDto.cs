using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using DevExpress.Office.Utils;

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
        public decimal TotalDollar { get; set; }
        public decimal TotalRiel { get; set; }
        public decimal ExchangeRate { get; set; }
        public string CurrencySymbol { get; set; } = "$";
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
        public decimal ExchangeRate { get; set; }
        public string CurrencySymbol { get; set; } = "$";
        public List<CreditNoteFlattenDataSource> Items { get; set; }
    }
}
