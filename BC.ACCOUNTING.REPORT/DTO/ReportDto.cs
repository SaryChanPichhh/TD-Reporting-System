using DevExpress.Xpo;
using System.ComponentModel;
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
        [Browsable(false)] public Languages? Language { get; set; } = Languages.KM;
        [Browsable(false)] public IsoNumericCountryCode? CountryCode { get; set; } = IsoNumericCountryCode.CAMBODIA;
        [Browsable(false)][Nullable(true)] public string DbCode { get; set; } = string.Empty;
        [Nullable(true)] public string CurrencySymbol { get; set; } = "$";
        [Nullable(true)] public string SubCurrencySymbol { get; set; } = "៛";
        [Browsable(false)][Nullable(true)] public DecimalFormatting DecimalPrecision { get; set; }  = DecimalFormatting.ThreeDecimalPrecision;
        [Browsable(false)][Nullable(true)] public DecimalFormatting SubDecimalPrecision { get; set; }  = DecimalFormatting.Standard;
        [OnDeserialized]
        private void InitializeData(StreamingContext context)
        {
            
        }
    }   
}
