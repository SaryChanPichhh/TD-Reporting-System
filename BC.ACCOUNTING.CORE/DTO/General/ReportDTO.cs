using System.ComponentModel;
using BC.ACCOUNTING.CORE.Enums;
using System.Runtime.Serialization;

namespace BC.ACCOUNTING.CORE.DTO.General
{
    public class ReportDTO
    {
        [Browsable(false)] public required string ReportName { get; set; }
        [Browsable(false)] public Export? ExportFormat { get; set; } = null; // null = View, otherwise Export
        [Browsable(false)] public string Connection { get; set; } = "Default";
        public string CurrencySymbol { get; set; } = "$";
        public string SubCurrencySymbol { get; set; } = "៛";
        [Browsable(false)]public DecimalFormatting DecimalPrecision { get; set; } = DecimalFormatting.ThreeDecimalPrecision;
        [Browsable(false)]public DecimalFormatting SubDecimalPrecision { get; set; } = DecimalFormatting.Standard;

        [OnDeserialized]
        private void InitializeData(StreamingContext context)
        {
            // Init Default Currency Symbol
            CurrencySymbol = string.IsNullOrEmpty(CurrencySymbol.Trim()) ? "$" : CurrencySymbol;
            SubCurrencySymbol = string.IsNullOrEmpty(SubCurrencySymbol.Trim()) ? "៛" : SubCurrencySymbol;
            // Init Default Decimal Precision
            DecimalPrecision = CurrencySymbol.Equals("៛") ? DecimalFormatting.Standard : DecimalFormatting.ThreeDecimalPrecision;
            SubDecimalPrecision = SubCurrencySymbol.Equals("$") ? DecimalFormatting.ThreeDecimalPrecision : DecimalFormatting.Standard;
        }
    }
    
    public enum Export
    {
        Pdf = 1,
        Excel = 2,
        Word = 3,
        Image = 4,
    }

}
