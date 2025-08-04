using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Order
{
    public partial class SaleInvoiceA5Report : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleInvoiceA5Report()
        {
            InitializeComponent();
        }

        public SaleInvoiceA5Report(SaleInvoiceDto dto, string reportName)
        {
            //this.LoadLayoutFromXml(reportName);
            //var data = ReportExtension.Flatten(dto);
            //objectDataSource1.DataSource = data;
            //this.DataSource = objectDataSource1;

            //Parameters["CustomerCode"].Value = dto.CustomerCode;
            //Parameters["CustomerName"].Value = dto.CustomerName;
            //Parameters["Market"].Value = dto.Market;
            //Parameters["Address"].Value = dto.Address;
            //Parameters["InvoiceIssuer"].Value = dto.InvoicePrinted;
            //Parameters["TransRef"].Value = dto.InvoiceNumber;
            //Parameters["Phone"].Value = dto.Phone;
            //Parameters["TransDate"].Value = dto.InvoiceDate;
            //Parameters["DueDate"].Value = dto.DueDate;
            //Parameters["Discount"].Value = dto.Discount;
            //Parameters["ExchangeRate"].Value = dto.ExchangeRate;
            //Parameters["Total"].Value = dto.SubTotal;
            //Parameters["TotalRiel"].Value = dto.ExchangeRate * dto.SubTotal;
            //Parameters["TotalDollar"].Value = dto.SubTotal;
            //Parameters["Note"].Value = dto.Note;
            //Parameters["Seller"].Value = dto.Seller;

        }
    }
}
