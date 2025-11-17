using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AP
{
    public partial class APCustomerVoucherReport : DevExpress.XtraReports.UI.XtraReport
    {
        public APCustomerVoucherReport()
        {
            InitializeComponent();
        }
        public APCustomerVoucherReport(ArCustomerPaidDto dto , string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }
    }
}
