using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO;
using DevExpress.DataAccess.ObjectBinding;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.AR
{
    public partial class ARCustomerSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ARCustomerSummaryReport()
        {
            InitializeComponent();
        }
        public ARCustomerSummaryReport(ArCustomerSummaryDto dto,string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
