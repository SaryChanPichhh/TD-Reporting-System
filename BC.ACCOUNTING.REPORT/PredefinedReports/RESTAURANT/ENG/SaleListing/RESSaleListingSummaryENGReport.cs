using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.ENG.SaleListing
{
    public partial class RESSaleListingSummaryENGReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingSummaryENGReport()
        {
            InitializeComponent();
        }

        public RESSaleListingSummaryENGReport(RESSaleListingSummaryDto dto, string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.DataSource = dto;
        }
    }
}
