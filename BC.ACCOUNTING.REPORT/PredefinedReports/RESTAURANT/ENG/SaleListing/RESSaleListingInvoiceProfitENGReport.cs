using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.ENG.SaleListing
{
    public partial class RESSaleListingInvoiceProfitENGReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingInvoiceProfitENGReport()
        {
            InitializeComponent();
        }

        public RESSaleListingInvoiceProfitENGReport(RESSaleListingInvoiceDto dto, string reportName)
        {

            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
