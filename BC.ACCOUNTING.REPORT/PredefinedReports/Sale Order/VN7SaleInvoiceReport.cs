using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Order
{
    public partial class VN7SaleInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public VN7SaleInvoiceReport()
        {
            InitializeComponent();
        }
        private List<ImageItem> saleInvoiceDto { get; set; }
        public VN7SaleInvoiceReport(SaleInvoiceDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            //InitializeComponent();
            saleInvoiceDto = dto.PictureItems;
            var data = ReportExtension.Flatten(dto);
            objectDataSource1.DataSource = data;
            DetailReport1.DataSource = objectDataSource1;
            Parameters["CustomerCode"].Value = dto.CustomerCode;
            Parameters["CustomerName"].Value = dto.CustomerName;
            Parameters["CustomerTel"].Value = dto.CustomerTel;
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
            Parameters["TotalRiel"].Value = dto.TotalKHR;
            Parameters["TotalDollar"].Value = dto.TotalUSD;
            Parameters["Note"].Value = dto.Note;
            Parameters["Seller"].Value = dto.Seller;
            Parameters["Field1"].Value = dto.Field1;
            Parameters["Field2"].Value = dto.Field2;
            Parameters["Field3"].Value = dto.Field3;
            Parameters["Field4"].Value = dto.Field4;
            Parameters["Field5"].Value = dto.Field5;
            Parameters["Field6"].Value = dto.Field6;
            Parameters["Field7"].Value = dto.Field7;
            Parameters["Field8"].Value = dto.Field8;
            Parameters["Field9"].Value = dto.Field9;


            objectDataSource2.DataSource = dto.PictureItems;
            DetailReport.DataSource = objectDataSource2;
            //xrSubreport1.BeforePrint += xrSubreport1_BeforePrint;

        }

      
        private void DetailReport_BeforePrint(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as SaleInvoiceDto;
            e.Cancel = data?.PictureItems == null || !data.PictureItems.Any();
        }

        private void xrSubreport1_BeforePrint(object sender, CancelEventArgs e)
        {
            var sub = (XRSubreport)sender;

            // Reuse the child if possible; create if null
            if (sub.ReportSource == null)
                sub.ReportSource = new QrCodeReport();
            var child = (XtraReport)sub.ReportSource;
            child.RequestParameters = false;
            child.DataSource = saleInvoiceDto;

            
        }
    }
}
