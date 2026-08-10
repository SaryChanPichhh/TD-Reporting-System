using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.ENG.SaleListing
{
    public partial class RESSaleListingMovementENGReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingMovementENGReport()
        {
            InitializeComponent();
        }
        public RESSaleListingMovementENGReport(RESSaleListingMovementDto dto, string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource1.DataSource = dto;
        }
    }
}
