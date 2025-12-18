using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;

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
            if (Parameters["DecimalPrecision"] is not null)
                DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            if (Parameters["SubDecimalPrecision"] is not null)
                SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();

        }
    }
}
