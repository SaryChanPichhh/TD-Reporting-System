using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DTO;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Order
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
            SaleReportDataSource.DataSource = saleReportDataSources;
            this.DataSource = SaleReportDataSource;
        }
        public DailySaleReport(string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
        }
        private void xrTableCell8_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
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


        private void xrTableCell16_PrintOnPage(object sender, DevExpress.XtraReports.UI.PrintOnPageEventArgs e)
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
