using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Inventory.IU
{
    public partial class POSInventoryAuditA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public POSInventoryAuditA4Report()
        {
            InitializeComponent();
        }

        public POSInventoryAuditA4Report(InventoryDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }
    }
}
