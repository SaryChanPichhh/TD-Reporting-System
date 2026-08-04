using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order.TD7
{
    public partial class TDSaleServiceA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public TDSaleServiceA4Report()
        {
            InitializeComponent();
        }
        public TDSaleServiceA4Report(QuotationDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            if (this.Parameters["SubDecimalPrecision"] is not null)
                this.SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
