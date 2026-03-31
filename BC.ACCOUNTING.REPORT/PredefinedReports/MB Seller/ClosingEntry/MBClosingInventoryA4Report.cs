using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.ClosingEntry
{
    public partial class MBClosingInventoryA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public MBClosingInventoryA4Report()
        {
            InitializeComponent();
        }
        public MBClosingInventoryA4Report(ClosingInventoryDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            if (Parameters["SubDecimalPrecision"] is not null)
            {
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            if (Parameters["DecimalPrecision"] is not null)
            {
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if (Parameters["TotalReceived_PRM"] != null)
                Parameters["TotalReceived_PRM"].Value = dto.TotalReceived;

            if (Parameters["TotalReceivedRiel_PRM"] != null)
                Parameters["TotalReceivedRiel_PRM"].Value = dto.TotalReceivedRiel;
            objectDataSource1.DataSource = dto;

        }
    }
}
