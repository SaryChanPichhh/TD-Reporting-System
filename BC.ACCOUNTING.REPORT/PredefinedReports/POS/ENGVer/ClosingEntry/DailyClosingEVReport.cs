using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.ClosingEntry
{
    public partial class DailyClosingEVReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DailyClosingEVReport()
        {
            InitializeComponent();
        }

        public DailyClosingEVReport(DailyClosingsDto inventoryDto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = inventoryDto;
            this.DataSource = objectDataSource1;

        }
    }
}
