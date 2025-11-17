using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ARDepreciationReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ARDepreciationReport()
        {
            InitializeComponent();
        }

        public ARDepreciationReport(ArDepreciationDto dto, string reportName)
        {
           this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
           this.DataSource = objectDataSource1;
        }
    }
}
