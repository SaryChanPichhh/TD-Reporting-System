using BC.ACCOUNTING.REPORT.DTO.MB;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Items
{
    public partial class ItemInfoReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ItemInfoReport()
        {
            InitializeComponent();
        }public ItemInfoReport(ItemInfoDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource1.DataSource = dto;
        }
    }
}
