using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Order
{
    public partial class VN7SaleInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public VN7SaleInvoiceReport()
        {
            InitializeComponent();
        }

        public VN7SaleInvoiceReport(SaleInvoiceDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            //InitializeComponent();
            var data = ReportExtension.Flatten(dto);
            objectDataSource1.DataSource = data;
            this.DataSource = objectDataSource1;
            Parameters["CustomerCode"].Value = dto.CustomerCode;
            Parameters["CustomerName"].Value = dto.CustomerName;
            Parameters["Market"].Value = dto.Market;
            Parameters["Address"].Value = dto.Address;
            Parameters["InvoiceIssuer"].Value = dto.InvoicePrinted;
            Parameters["TransRef"].Value = dto.InvoiceNumber;
            Parameters["Phone"].Value = dto.Phone;
            Parameters["TransDate"].Value = dto.InvoiceDate;
            Parameters["DueDate"].Value = dto.DueDate;
            Parameters["Discount"].Value = dto.Discount;
            Parameters["ExchangeRate"].Value = dto.ExchangeRate;
            Parameters["Total"].Value = dto.SubTotal;
            Parameters["TotalRiel"].Value = dto.ExchangeRate * dto.SubTotal;
            Parameters["TotalDollar"].Value = dto.SubTotal;
            Parameters["Note"].Value = dto.Note;
            Parameters["Seller"].Value = dto.Seller;


            objectDataSource2.DataSource = dto.PictureItems;
            DetailReport.DataSource = objectDataSource2;
        }

        private void DetailReport_BeforePrint(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as SaleInvoiceDto;
            e.Cancel = data?.PictureItems == null || !data.PictureItems.Any();
        }
    }
}
