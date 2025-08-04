using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources;

namespace BC.ACCOUNTING.REPORT.PredefinedReports
{
    public partial class ReportDividedInvoiceToDeliveries : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportDividedInvoiceToDeliveries()
        {
            InitializeComponent();
        }

        public void InitData(List<ReportDividedInvoiceToDeliveriesDataSource> reportDividedInvoiceTo, string deliveryName)
        {
            this.objectDataSource1.DataSource = reportDividedInvoiceTo;
            DeliveryName.Value = deliveryName;
        }
    }
}
