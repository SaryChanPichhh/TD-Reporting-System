using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.Inventory
{
    public partial class POSInventoryOutOfStockEVReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSInventoryOutOfStockEVReport()
        {
            InitializeComponent();
        }
        public POSInventoryOutOfStockEVReport(POSItemDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource.DataSource = dto;
        }
    }
}
