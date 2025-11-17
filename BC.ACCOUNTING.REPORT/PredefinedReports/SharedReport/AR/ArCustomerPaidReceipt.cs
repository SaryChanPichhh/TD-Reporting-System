using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ArCustomerPaidReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerPaidReceipt()
        {
            InitializeComponent();
        }
        public ArCustomerPaidReceipt(ArCustomerPaidDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
