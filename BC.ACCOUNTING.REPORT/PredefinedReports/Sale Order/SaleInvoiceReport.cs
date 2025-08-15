using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;
using BC.ACCOUNTING.REPORT.Models;
using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Order
{
    public partial class SaleInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleInvoiceReport()
        {
            InitializeComponent();
            objectDataSource1.DataSource = new List<FlatInvoiceRow>();
            this.DataSource = objectDataSource1;
        }

        public SaleInvoiceReport(SaleInvoiceDto dto,string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            var data = ReportExtension.Flatten(dto);
            objectDataSource1.DataSource = data;
            this.DataSource = objectDataSource1;
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
            Parameters["IsVisible"].Value = dto.IsVisible;
            


            //Parameters["CustomerCode"].Value = dto.CustomerCode;
            //Parameters["CustomerName"].Value = dto.CustomerName;
            //Parameters["CustomerTel"].Value = dto.CustomerTel;
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
            //Parameters["TotalRiel"].Value = dto.TotalKHR;
            //Parameters["TotalDollar"].Value = dto.TotalUSD;
            //Parameters["Note"].Value = dto.Note;
            //Parameters["Seller"].Value = dto.Seller;

        }
    }
}
