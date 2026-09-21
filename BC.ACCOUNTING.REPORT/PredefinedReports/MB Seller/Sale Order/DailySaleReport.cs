using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.XtraReports.UI;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order
{
    public partial class DailySaleReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DailySaleReport()
        {
            InitializeComponent();
        }

        public DailySaleReport(InvoiceReportDto saleReportDataSources,string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
            if (Parameters["DecimalPrecision"] is not null)
            {
                this.Parameters["DecimalPrecision"].Value = saleReportDataSources.DecimalPrecision.GetEnumDescription();
            }
            else if (Parameters["SubDecimalPrecision"] is not null)
            {
                this.Parameters["SubDecimalPrecision"].Value = saleReportDataSources.SubDecimalPrecision.GetEnumDescription();
            }
            SaleReportDataSource.DataSource = saleReportDataSources;
        }
    }
}
