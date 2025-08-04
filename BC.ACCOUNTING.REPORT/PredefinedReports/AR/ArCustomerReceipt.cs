using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.AR
{
    public partial class ArCustomerReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerReceipt()
        {
            InitializeComponent();
        }

        public ArCustomerReceipt(ArCustomerDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
