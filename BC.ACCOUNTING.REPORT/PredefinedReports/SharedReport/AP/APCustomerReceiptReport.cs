using BC.ACCOUNTING.REPORT.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AP
{
    public partial class APCustomerReceiptReport : DevExpress.XtraReports.UI.XtraReport
    {
        public APCustomerReceiptReport()
        {
            InitializeComponent();
        }
        public APCustomerReceiptReport(ArCustomerDto dto , string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }
    }
}
