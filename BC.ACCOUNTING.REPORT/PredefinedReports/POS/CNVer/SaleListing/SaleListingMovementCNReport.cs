using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.China.SaleListing
{
    public partial class SaleListingMovementCNReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleListingMovementCNReport()
        {
            InitializeComponent();
        }

        public SaleListingMovementCNReport(POSSaleListingMovementDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);

            //CultureInfo.DefaultThreadCurrentCulture = kh;
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;

        }
    }
}
