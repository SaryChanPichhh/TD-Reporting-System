using BC.ACCOUNTING.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.CORE.Entities
{
    public class SettingInvoicePresetModel
    {
        public string DbCode { get; set; } = string.Empty;
        public bool ShowShopName { get; set; }
        public bool ShowVat { get; set; }
        public bool ShowReceive { get; set; }
        public string Note { get; set; } = string.Empty;
        public bool ShowRemain { get; set; }
        public bool ShowNote { get; set; }
        public bool ShowCustTel { get; set; }
        public bool ShowCustAddress { get; set; }
        public string LogoShape { get; set; } = string.Empty;
        public bool ShowImage { get; set; }
        public int Spacing { get; set; }
        public int FontSize { get; set; }
        public bool ShowDiscount { get; set; }
        public int NumberDigit { get; set; }
        public bool ShowImageQr { get; set; }
        public bool ShowImageQrFrontScreen { get; set; }
    }
}
