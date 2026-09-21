using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.China.SaleListing
{
    public partial class POSSaleListingSummaryCNReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleListingSummaryCNReport()
        {
            InitializeComponent();
        }
        public POSSaleListingSummaryCNReport(POSSalelistingSummaryDto dto, string reportName)
        {
            LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            objectDataSource1.DataSource = dto;
        }
    }
}
