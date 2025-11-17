using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.SaleListing
{
    public partial class POSSaleListingEVReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleListingEVReport()
        {
            InitializeComponent();
        }
        public POSSaleListingEVReport(POSSaleListingReportDto dto,string reportName)
        {
    

            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;

        }
    }
}
