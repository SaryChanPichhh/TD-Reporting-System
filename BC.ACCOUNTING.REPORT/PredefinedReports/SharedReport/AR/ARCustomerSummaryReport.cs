using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ARCustomerSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ARCustomerSummaryReport()
        {
            InitializeComponent();
        }
        public ARCustomerSummaryReport(ArCustomerSummaryDto dto,string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
