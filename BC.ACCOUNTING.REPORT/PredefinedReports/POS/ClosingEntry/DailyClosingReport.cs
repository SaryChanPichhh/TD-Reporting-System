using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.Helper;

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
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = inventoryDto.DecimalPrecision.GetEnumDescription();
            objectDataSource1.DataSource = inventoryDto;
            this.DataSource = objectDataSource1;

        }
    }
}
