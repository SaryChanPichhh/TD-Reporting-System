using BC.ACCOUNTING.REPORT.DTO.MB;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Listing
{
    public sealed partial class MBSaleListingSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public MBSaleListingSummaryReport()
        {
            InitializeComponent();                         
        }
        public MBSaleListingSummaryReport(MBSaleListingSummaryDto dto, string reportName)
        {
            
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }

        private void MBSaleListingSummaryReport_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
