using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;

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
            if (Parameters["DecimalPrecision"] != null)
            {
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if (Parameters["SubDecimalPrecision"] != null)
            {
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            objectDataSource1.DataSource = dto;
           this.DataSource = objectDataSource1;
        }
    }
}
