
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.Helper.Enums
{
    public enum DecimalFormatting
    {
        [Description("{0:#,###,##0}")]
        Standard = 0,
        [Description("{0:# ### ##0.#}")]
        OneDecimalPrecision = 1,
        [Description("{0:# ### ##0.##}")]
        TwoDecimalPrecision = 2,    
        [Description("{0:# ### ##0.###}")]
        ThreeDecimalPrecision = 3,
        [Description("{0:# ### ##0.####}")]
        FourDecimalPrecision = 4,
        [Description("{0:# ### ##0.#####}")]
        FiveDecimalPrecision = 5,
        [Description("{0:# ### ##0.######}")]
        SixDecimalPrecision = 6,     
        [Description("{0:# ### ##0.0}")]
        OneDecimalWithTrailingZero = 11,
        [Description("{0:# ### ##0.00}")]
        TwoDecimalWithTrailingZero = 12,
        [Description("{0:# ### ##0.000}")]
        ThreeDecimalWithTrailingZero = 13,
        [Description("{0:# ### ##0.0000}")]
        FourDecimalWithTrailingZero = 14,
        [Description("{0:# ### ##0.00000}")]
        FiveDecimalWithTrailingZero = 15,
        [Description("{0:# ### ##0.000000}")]
        SixDecimalWithTrailingZero = 16,
    }
}
