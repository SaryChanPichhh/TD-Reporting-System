using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.CustomerOrder
{
    public partial class CustomerOrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CustomerOrderReport()
        {
            InitializeComponent();
        }
        public CustomerOrderReport(InvoiceItemDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
