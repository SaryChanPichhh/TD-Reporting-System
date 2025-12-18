using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;

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
            if (Parameters["DecimalPrecision"] != null)
            {
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if (Parameters["SubDecimalPrecision"] != null)
            {
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            objectDataSource1.DataSource = dto;

        }

        private void MBSaleListingSummaryReport_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
