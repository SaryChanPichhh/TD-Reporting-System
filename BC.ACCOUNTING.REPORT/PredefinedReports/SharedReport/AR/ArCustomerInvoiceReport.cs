using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ArCustomerInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerInvoiceReport()
        {
            InitializeComponent();
        }
        public ArCustomerInvoiceReport(ArCustomerInvoiceDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            if (Parameters["DecimalPrecision"] is not null)
                DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            if (Parameters["SubDecimalPrecision"] is not null)
                DecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            this.objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
