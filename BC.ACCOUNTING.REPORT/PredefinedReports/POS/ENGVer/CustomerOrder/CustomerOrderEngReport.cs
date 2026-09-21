using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.CustomerOrder
{
    public partial class CustomerOrderEngReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CustomerOrderEngReport()
        {
            InitializeComponent();
        }
        public CustomerOrderEngReport(InvoiceItemDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
