using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ARPaidReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ARPaidReport()
        {
            InitializeComponent();
        }
        public ARPaidReport(ArPaidDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
            //var count = dto.Items
            //    .Select(x => x.TransRef)
            //    .Distinct()
            //    .Count();

        }
    }
}
