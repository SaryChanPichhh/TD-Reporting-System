using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.AR
{
    public partial class ArCustomerPaidReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerPaidReceipt()
        {
            InitializeComponent();
        }
        public ArCustomerPaidReceipt(ArCustomerPaidDto dto,string reportName)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
            this.DataSource = objectDataSource1;
        }
    }
}
