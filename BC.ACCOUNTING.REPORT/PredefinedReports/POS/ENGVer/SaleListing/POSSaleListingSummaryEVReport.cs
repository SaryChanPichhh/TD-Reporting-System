using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.SaleListing
{
    public partial class POSSaleListingSummaryEVReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleListingSummaryEVReport()
        {
            InitializeComponent();
        }
        public POSSaleListingSummaryEVReport(POSSalelistingSummaryDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }
    }
}
