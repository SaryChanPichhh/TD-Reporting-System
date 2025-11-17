using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO;
using DevExpress.XtraReports.UI;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order
{
    public partial class DailySale80Report : DevExpress.XtraReports.UI.XtraReport
    {
        public DailySale80Report()
        {
            InitializeComponent();
        }

        public DailySale80Report(InvoiceReportDto saleReportDataSources, string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
            SaleReportDataSource.DataSource = saleReportDataSources;
            this.DataSource = SaleReportDataSource;
        }

        private void xrTableCell8_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;

            if (cell != null)
            {
                string rawText = cell.Text.Replace("$", "").Replace(",", "").Trim();

                if (double.TryParse(rawText, out double value))
                {
                    if (value > 0)
                        cell.ForeColor = Color.Green;
                    else if (value < 0)
                        cell.ForeColor = Color.Red;
                    else
                        cell.ForeColor = Color.Black;
                }
                else
                {
                    cell.ForeColor = Color.Black;
                }
            }
        }

        private void xrTableCell24_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;

            if (cell != null)
            {
                string rawText = cell.Text.Replace("$", "").Replace(",", "").Trim();

                if (double.TryParse(rawText, out double value))
                {
                    if (value > 0)
                        cell.ForeColor = Color.Green;
                    else if (value < 0)
                        cell.ForeColor = Color.Red;
                    else
                        cell.ForeColor = Color.Black;
                }
                else
                {
                    cell.ForeColor = Color.Black;
                }
            }
        }
    }
}
