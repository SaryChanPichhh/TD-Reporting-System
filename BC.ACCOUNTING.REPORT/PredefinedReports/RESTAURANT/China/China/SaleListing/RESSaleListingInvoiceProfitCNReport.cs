using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.China.SaleListing
{
    public partial class RESSaleListingInvoiceProfitCNReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingInvoiceProfitCNReport()
        {
            InitializeComponent();
        }

        public RESSaleListingInvoiceProfitCNReport(RESSaleListingInvoiceDto dto, string reportName)
        {

            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
