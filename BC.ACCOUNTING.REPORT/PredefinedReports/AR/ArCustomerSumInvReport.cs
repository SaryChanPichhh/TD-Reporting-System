using BC.ACCOUNTING.REPORT.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.AR
{
    public partial class ArCustomerSumInvReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerSumInvReport()
        {
            InitializeComponent();
        }
        public ArCustomerSumInvReport(ArCustomerSumInvDto​ dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
