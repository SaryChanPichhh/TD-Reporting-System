using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.CustomerOrder
{
    public partial class CustomerOrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CustomerOrderReport()
        {
            InitializeComponent();
        }
        public CustomerOrderReport(InvoiceItemDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
