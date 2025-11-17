using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ArCustomerReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerReceipt()
        {
            InitializeComponent();
        }

        public ArCustomerReceipt(ArCustomerDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
