using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.Models;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order
{
    public partial class InvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceReport()
        {
            InitializeComponent();
            objectDataSource1.DataSource = new List<FlatInvoiceRow>();
            this.DataSource = objectDataSource1;
        }

        public InvoiceReport(List<FlatInvoiceRow> dto)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
