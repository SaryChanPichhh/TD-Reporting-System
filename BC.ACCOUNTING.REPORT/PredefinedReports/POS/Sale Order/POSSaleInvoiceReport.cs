using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using BC.ACCOUNTING.REPORT.DTO.POS;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrinting.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Sale_Order
{
    public partial class POSSaleInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleInvoiceReport()
        {
            InitializeComponent();
        }
        public POSSaleInvoiceReport(POSSaleInvoiceDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            var pictureBox = sender as XRPictureBox;
            var data = GetCurrentRow() as POSSaleInvoiceDto;

            if (string.IsNullOrEmpty(data?.ShopImage)) return;
            try
            {
                // Check if it's a local file
                if (File.Exists(data.ShopImage))
                {
                    pictureBox.Image = Image.FromFile(data.ShopImage);
                }
                else if (Uri.IsWellFormedUriString(data.ShopImage, UriKind.Absolute))
                {
                    using var client = new System.Net.WebClient();
                    var imageBytes = client.DownloadData(data.ShopImage);
                    using var ms = new MemoryStream(imageBytes);
                    pictureBox.Image = Image.FromStream(ms);
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
}
