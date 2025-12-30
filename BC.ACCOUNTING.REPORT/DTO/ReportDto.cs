using BC.ACCOUNTING.REPORT.Models;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Diagnostics;
using BC.ACCOUNTING.REPORT.Helper;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using System.Runtime.Serialization;

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
        [Browsable(false)][Nullable(true)] public DecimalFormatting DecimalPrecision { get; set; }  = DecimalFormatting.ThreeDecimalPrecision;
        [Browsable(false)][Nullable(true)] public DecimalFormatting SubDecimalPrecision { get; set; }  = DecimalFormatting.Standard;
        [OnDeserialized]
        private void InitializeData(StreamingContext context)
        {
            // Init Default Currency Symbol
            CurrencySymbol = string.IsNullOrEmpty(CurrencySymbol.Trim()) ? "$" : CurrencySymbol;
            SubCurrencySymbol = string.IsNullOrEmpty(SubCurrencySymbol.Trim()) ? "៛" : SubCurrencySymbol;
            // Init Default Decimal Precision
            DecimalPrecision = CurrencySymbol.Equals("៛")? DecimalFormatting.TwoDecimalPrecision : DecimalFormatting.ThreeDecimalPrecision;
            SubDecimalPrecision = SubCurrencySymbol.Equals("$")? DecimalFormatting.ThreeDecimalPrecision : DecimalFormatting.Standard;
        }
    }   
}
