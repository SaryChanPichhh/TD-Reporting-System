using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.Helper;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.SubReport;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraReports.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Sale_Order
{
    public partial class POSSaleInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleInvoiceReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Row limit for the first page — kept lower so the ReportFooter has
        /// room to land on a new page without being clipped.
        /// </summary>
        private const int FooterBreakThreshold = 16;

        /// <summary>
        /// Row limit for every page after the first break. No footer competes
        /// for space on these pages, so the full 20 rows are available.
        /// </summary>
        private const int FullPageRowLimit = 30;
        private int _rowCount = 0;
        private bool _firstBreakDone = false;
        private int totalRow = 0;
        public POSSaleInvoiceReport(POSSaleInvoiceDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            if (xrSubreport1 is not null)
            {
                xrSubreport1.BeforePrint += xrSubreport1_BeforePrint;
            }
            if (Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            totalRow = dto.Items.Count;
            var match = ReportHelper.GetReportConfigByName(dto.ReportName);
            if (match != default)
            {
                this.Detail.BeforePrint += Detail_BeforePrint;
            }
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            _rowCount++;
            var threshold = _firstBreakDone ? FullPageRowLimit : FooterBreakThreshold;
            if (_rowCount >= threshold && _rowCount==totalRow) 
            {
                Detail.PageBreak = PageBreak.AfterBand;
                _rowCount = 0;
                _firstBreakDone = true;
            }
            else if (_rowCount >= 20)
            {
                if (!_firstBreakDone)
                {
                    Detail.PageBreak = PageBreak.AfterBand;
                    _firstBreakDone = true;
                    totalRow -= _rowCount;
                    _rowCount = 0;
                }
            }
            else
            {
                Detail.PageBreak = PageBreak.None;
            }
            if ((_firstBreakDone && _rowCount >= 23 && totalRow == _rowCount) || (_firstBreakDone && _rowCount >= 27))
            {
                Detail.PageBreak = PageBreak.AfterBand;
                _rowCount = 0;
            }
            
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

        private void xrSubreport1_BeforePrint(object sender, CancelEventArgs e)
        {
            var subReport = new ShowImagesReport();
            if (GetCurrentRow() is POSSaleInvoiceDto currentRow)
            {
                if (currentRow.Images is null or [])
                {
                    subReport.Visible = false;
                }
                if (currentRow.Images is not null or not [])
                {
                    subReport.DataSource = currentRow.Images;
                }
            }
            ((XRSubreport)sender).ReportSource = subReport;
        }
    }
}
