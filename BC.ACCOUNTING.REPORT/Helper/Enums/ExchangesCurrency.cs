using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.Helper
{
    public enum ExchangesCurrency
    {
        [Description("$")] USD = 1,
        [Description("៛")] KHR = 2,
        [Description("฿")] BTH = 3,
        [Description("₫")] VND = 4,
    }
}
