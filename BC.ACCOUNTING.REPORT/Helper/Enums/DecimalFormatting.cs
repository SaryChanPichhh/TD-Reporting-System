
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.Helper.Enums
{
    public enum DecimalFormatting
    {
        [Description("{0:#,##0}")]
        Standard = 0,
        [Description("{0:#,##0.#}")]
        OneDecimalPrecision = 1,
        [Description("{0:#,##0.##}")]
        TwoDecimalPrecision = 2,    
        [Description("{0:#,##0.###}")]
        ThreeDecimalPrecision = 3,
        [Description("{0:#,##0.####}")]
        FourDecimalPrecision = 4,
        [Description("{0:#,##0.#####}")]
        FiveDecimalPrecision = 5,
    }
}
