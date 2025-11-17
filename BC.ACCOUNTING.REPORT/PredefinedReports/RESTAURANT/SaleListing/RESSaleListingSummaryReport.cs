using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;
using DevExpress.XtraGauges.Core.Model;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.SaleListing
{
    public partial class RESSaleListingSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingSummaryReport()
        {
            InitializeComponent();
        }

        public RESSaleListingSummaryReport(RESSaleListingSummaryDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.DataSource= dto;
        }
    }
}
