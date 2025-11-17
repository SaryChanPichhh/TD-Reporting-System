using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.CustomerOrder
{
    public partial class CustomerOrderEVReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CustomerOrderEVReport()
        {
            InitializeComponent();
        }
        public CustomerOrderEVReport(InvoiceItemDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
