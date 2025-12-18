using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;
using BC.ACCOUNTING.CORE.Enums;

namespace BC.ACCOUNTING.CORE.DTO.General
{
    public class ReportDTO
    {
        [Browsable(false)] public required string ReportName { get; set; }
        [Browsable(false)] public Export? ExportFormat { get; set; } = null; // null = View, otherwise Export
        [Browsable(false)] public string Connection { get; set; } = "Default";
        public string CurrencySymbol { get; set; } = "$";
        public string SubCurrencySymbol { get; set; } = "៛";
        [Browsable(false)]public DecimalFormatting DecimalPrecision { get; set; } = DecimalFormatting.TwoDecimalPrecision;
        [Browsable(false)]public DecimalFormatting SubDecimalPrecision { get; set; } = DecimalFormatting.Standard;
    }
    public enum Export
    {
        Pdf = 1,
        Excel = 2,
        Word = 3,
        Image = 4,
    }

}
