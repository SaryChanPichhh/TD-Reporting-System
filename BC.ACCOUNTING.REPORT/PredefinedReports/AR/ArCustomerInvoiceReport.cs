using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.AR
{
    public partial class ArCustomerInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerInvoiceReport()
        {
            InitializeComponent();
        }
        public ArCustomerInvoiceReport(ArCustomerInvoiceDto dto, string reportName)
        {
            InitializeComponent();
            this.objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
