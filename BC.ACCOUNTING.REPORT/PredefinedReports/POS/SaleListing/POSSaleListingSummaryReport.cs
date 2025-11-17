using BC.ACCOUNTING.REPORT.DTO.POS;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.SaleListing
{
    public partial class POSSaleListingSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleListingSummaryReport()
        {
            InitializeComponent();
        }
        public POSSaleListingSummaryReport(POSSalelistingSummaryDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }
    }
}
