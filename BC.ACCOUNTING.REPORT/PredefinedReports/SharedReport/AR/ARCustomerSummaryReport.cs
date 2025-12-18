using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ARCustomerSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ARCustomerSummaryReport()
        {
            InitializeComponent();
        }
        public ARCustomerSummaryReport(ArCustomerSummaryDto dto,string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            if (Parameters["DecimalPrecision"] is not null)
                DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            if (Parameters["SubDecimalPrecision"] is not null)
                SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            this.DataSource = objectDataSource1;
        }
    }
}
