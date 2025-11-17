using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ArCustomerInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerInvoiceReport()
        {
            InitializeComponent();
        }
        public ArCustomerInvoiceReport(ArCustomerInvoiceDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            this.objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
