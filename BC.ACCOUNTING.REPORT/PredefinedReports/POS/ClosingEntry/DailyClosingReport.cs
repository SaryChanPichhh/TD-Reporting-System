using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ClosingEntry
{
    public partial class DailyClosingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DailyClosingReport()
        {
            InitializeComponent();
        }

        public DailyClosingReport(DailyClosingsDto inventoryDto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = inventoryDto;
            this.DataSource = objectDataSource1;

        }
    }
}
