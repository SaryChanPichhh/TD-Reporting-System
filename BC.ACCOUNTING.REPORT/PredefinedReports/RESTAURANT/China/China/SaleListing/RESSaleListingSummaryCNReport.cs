using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.China.SaleListing
{
    public partial class RESSaleListingSummaryCNReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingSummaryCNReport()
        {
            InitializeComponent();
        }

        public RESSaleListingSummaryCNReport(RESSaleListingSummaryDto dto, string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.DataSource = dto;
        }
    }
}
