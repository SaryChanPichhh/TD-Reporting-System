using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.SaleListing
{
    public partial class POSSaleListingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleListingReport()
        {
            InitializeComponent();
        }
        public POSSaleListingReport(POSSaleListingReportDto dto,string reportName)
        {
    

            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;

        }
    }
}
