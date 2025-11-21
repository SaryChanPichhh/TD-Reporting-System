using System;
using System.Diagnostics.CodeAnalysis;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class IncomeExpenseDataSource
    {
        public DateTime Date  { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ReferenceNo { get; set; }
        public int Qty { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; } = 0;
    }
}
