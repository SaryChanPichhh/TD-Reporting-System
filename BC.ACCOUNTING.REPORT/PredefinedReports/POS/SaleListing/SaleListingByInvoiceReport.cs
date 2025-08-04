using BC.ACCOUNTING.REPORT.DTO.POS;
using DevExpress.XtraReports.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.SaleListing
{
    public partial class SaleListingByInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleListingByInvoiceReport()
        {
            InitializeComponent();
        }
        public SaleListingByInvoiceReport(POSSaleListingByInvoiceDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
        
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
            xrPictureBox1.BeforePrint += xrPictureBox1_BeforePrint;
            xrTableCell34.BeforePrint += xrTableCell34_BeforePrint;
            xrTableCell11.PrintOnPage += xrTableCell31_PrintOnPage;
            xrTableCell24.PrintOnPage += xrTableCell24_PrintOnPage;
            
        }


        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            var pictureBox = sender as XRPictureBox;
            var data = GetCurrentRow() as POSSaleListingByInvoiceDto;

            if (!string.IsNullOrEmpty(data?.ShopImage))
            {
                try
                {
                    // Check if it's a local file
                    if (File.Exists(data.ShopImage))
                    {
                        pictureBox.Image = Image.FromFile(data.ShopImage);
                    }
                    else if (Uri.IsWellFormedUriString(data.ShopImage, UriKind.Absolute))
                    {
                        using (var client = new System.Net.WebClient())
                        {
                            byte[] imageBytes = client.DownloadData(data.ShopImage);
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                pictureBox.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    else
                    {
                        pictureBox.Image = null; // fallback or log
                    }
                }
                catch
                {
                    pictureBox.Image = null;
                }
            }
        }

        private void xrTableCell31_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ReportExtension.SetCellColorBasedOnValue(sender as XRTableCell);
        }

      

        private void xrTableCell34_BeforePrint(object sender, CancelEventArgs e)
        {
            ReportExtension.SetCellColorBasedOnValue(sender as XRTableCell);
        }

        private void xrTableCell11_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ReportExtension.SetCellColorBasedOnValue(sender as XRTableCell);

        }

        private void xrTableCell24_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ReportExtension.SetCellColorBasedOnValue(sender as XRTableCell);

        }
    }
}
