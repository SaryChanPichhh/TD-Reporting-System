using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.SaleListing
{
    public partial class RESSaleListingInvoiceProfitReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingInvoiceProfitReport()
        {
            InitializeComponent();
        }

        public RESSaleListingInvoiceProfitReport(RESSaleListingInvoiceDto dto, string reportName)
        {

            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
