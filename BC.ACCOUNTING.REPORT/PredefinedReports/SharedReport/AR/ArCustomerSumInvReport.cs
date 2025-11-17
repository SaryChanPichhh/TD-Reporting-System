using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ArCustomerSumInvReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerSumInvReport()
        {
            InitializeComponent();
        }
        public ArCustomerSumInvReport(ArCustomerSumInvDto​ dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
