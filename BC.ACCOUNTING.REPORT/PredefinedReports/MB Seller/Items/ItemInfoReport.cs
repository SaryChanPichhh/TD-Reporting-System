using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;

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
            if(this.Parameters["DecimalPrecision"] is not null)
            {
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if (this.Parameters["SubDecimalPrecision"] is not null)
            {
                this.DecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            this.objectDataSource1.DataSource = dto;
        }
    }
}
