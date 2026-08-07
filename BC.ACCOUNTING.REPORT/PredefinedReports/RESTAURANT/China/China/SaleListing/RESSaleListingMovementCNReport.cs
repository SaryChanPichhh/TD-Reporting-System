using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.China.SaleListing
{
    public partial class RESSaleListingMovementCNReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingMovementCNReport()
        {
            InitializeComponent();
        }
        public RESSaleListingMovementCNReport(RESSaleListingMovementDto dto, string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource1.DataSource = dto;
        }
    }
}
