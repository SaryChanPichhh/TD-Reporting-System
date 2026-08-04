using DevExpress.Office.Utils;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Sale_Order
{
    public partial class POSSaleInvoice80Report : XtraReport
    {
        public POSSaleInvoice80Report()
        {
            InitializeComponent();
        }
        public POSSaleInvoice80Report(POSSaleInvoiceDto items, SettingInvoicePresetModel printingPreset,string reportName)
        {
            LoadLayoutFromXml(reportName);
            if(Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = items.DecimalPrecision.GetEnumDescription();
            objectDataSourceItems.DataSource = items;
            DbCode.Value = printingPreset.DbCode;
            ShowShopName.Value = printingPreset.ShowShopName;
            FontSize.Value = printingPreset.FontSize;
            ShowImageQr.Value = printingPreset.ShowImageQr;
            NumberDigit.Value = printingPreset.NumberDigit;
            ShowDiscount.Value = printingPreset.ShowDiscount;
            Spacing.Value = printingPreset.Spacing;
            ShowImage.Value = printingPreset.ShowImage;
            LogoShape.Value = printingPreset.LogoShape;
            ShowCustTel.Value = printingPreset.ShowCustTel;
            ShowNote.Value = printingPreset.ShowNote;
            ShowRemain.Value = printingPreset.ShowRemain;
            ShowReceive.Value = printingPreset.ShowReceive;
            ShowVat.Value = printingPreset.ShowVat;
            ShowCustAddress.Value = printingPreset.ShowCustAddress;
            Note.Value = printingPreset.Note;
            ShowDelivery.Value = items.ShowDelivery;
            ShowSubTotal.Value = items.ShowSubTotal;
            ShowCashChange.Value = items.ShowCashChange;
            ShowRowNum.Value = items.ShowRowNum;

        }

    }
}
