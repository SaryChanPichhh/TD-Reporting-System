using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Inventory
{
    public partial class InventoryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InventoryReport()
        {
            InitializeComponent();
        }

        public InventoryReport(InventoryReportDto dto, string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
            objectDataSource.DataSource = dto;
            this.DataSource = objectDataSource;
            if(DetailReport is not null)
                DetailReport.Visible = dto.FIELD_4?.ToUpper() != "FALSE";
            if(Parameters["DecimalPrecision"] != null)
            {
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if(Parameters["SubDecimalPrecision"] != null)
            {
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
        }
        public InventoryReport(string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
        }
    }
}
