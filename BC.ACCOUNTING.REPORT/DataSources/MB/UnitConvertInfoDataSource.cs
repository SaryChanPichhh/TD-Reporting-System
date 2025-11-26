using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class UnitConvertInfoDataSource
    {
        public string UnitCode { get; set; }
        public string ConvFromKh { get; set; }
        public string ConvFromEn { get; set; }
        public string ConvToKh { get; set; }
        public string ConvToEn { get; set; }
        public decimal SalePrice { get; set; }
        public string Factor  { get; set; }
        [Nullable(true)]
        public decimal Cost { get; set; } = 0;
    }
}
