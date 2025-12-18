using BC.ACCOUNTING.REPORT.DTO.POS;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.Helper;

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
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            objectDataSource1.DataSource = dto;
        }
    }
}
