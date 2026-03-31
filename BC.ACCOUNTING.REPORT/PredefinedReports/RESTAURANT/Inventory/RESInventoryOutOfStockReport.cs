namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.Inventory
{
    public partial class RESInventoryOutOfStockReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESInventoryOutOfStockReport()
        {
            InitializeComponent();
        }
        public RESInventoryOutOfStockReport(RESItemDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource.DataSource = dto;
        }
    }
}
