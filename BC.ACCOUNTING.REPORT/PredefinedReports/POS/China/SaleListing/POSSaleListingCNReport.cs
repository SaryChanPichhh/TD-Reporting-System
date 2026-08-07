using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.China.SaleListing
{
    public partial class POSSaleListingCNReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleListingCNReport()
        {
            InitializeComponent();
        }

        public POSSaleListingCNReport(POSSaleListingReportDto dto, string reportName)
        {


            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;

        }
    }
}
