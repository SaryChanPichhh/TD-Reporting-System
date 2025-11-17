using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.SaleInvoice
{
    public partial class RESSaleReceipt58Report : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleReceipt58Report()
        {
            InitializeComponent();
        }public RESSaleReceipt58Report(RESSaleReceiptDto dto,string reportName)
        {
            InitializeComponent();
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }
    }
}
