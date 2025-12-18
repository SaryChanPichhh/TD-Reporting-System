using BC.ACCOUNTING.REPORT.Models;
using DevExpress.Xpo;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.Helper;
using BC.ACCOUNTING.REPORT.Helper.Enums;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ReportDto
    {
        [Browsable(false)]
        public string ReportName { get; set; }
        [Browsable(false)]
        public Export? ExportFormat { get; set; } = null; 
        [Browsable(false)] public string? Connection { get; set; } = "Default";
        [Browsable(false)][Nullable(true)] public string DbCode { get; set; } = string.Empty;
        [Nullable(true)] public string CurrencySymbol { get; set; } = "$";
        [Nullable(true)] public string SubCurrencySymbol { get; set; } = "៛";
        [Browsable(false)][Nullable(true)] public DecimalFormatting DecimalPrecision { get; set; }  = DecimalFormatting.TwoDecimalPrecision;
        [Browsable(false)][Nullable(true)] public DecimalFormatting SubDecimalPrecision { get; set; }  = DecimalFormatting.Standard;
    }
}
