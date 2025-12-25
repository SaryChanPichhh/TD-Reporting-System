using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;
using BC.ACCOUNTING.REPORT.Models;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using BC.ACCOUNTING.REPORT.Helper.Enums;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order
{
    public partial class SaleInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        private IConfiguration Configuration { get; }
        public SaleInvoiceReport()
        {
            InitializeComponent();
            
                objectDataSource1.DataSource = new List<FlatInvoiceRow>();
            this.DataSource = objectDataSource1;
        }

        private int _rowsOnCurrentPage;
        private bool _firstPageCompleted;
        private void Report_BeforePrint(object sender, CancelEventArgs e)
        {
            _rowsOnCurrentPage = 0;
            _firstPageCompleted = false;
        }

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            _rowsOnCurrentPage++;
            int limit = _firstPageCompleted ? 32:27;

            // Default: no page break
            Detail.PageBreak = PageBreak.None;

            if (_rowsOnCurrentPage >= limit)
            {
                //Debug.WriteLine( $@"Limit : {limit}");
                Detail.PageBreak = PageBreak.AfterBand;
                _rowsOnCurrentPage = 0;       // start counting next page
                _firstPageCompleted = true;
                // only the first page uses 25
            }
            else if ((_rowsOnCurrentPage - 27 < 5 && _rowsOnCurrentPage - 27 > 0))
            {
                if (_rowsOnCurrentPage >= 32)
                {
                    Detail.PageBreak = PageBreak.AfterBand;
                    _rowsOnCurrentPage = 0;
                    //this.ReportFooter.Visible = false;
                }
                else
                {
                    Detail.PageBreak = PageBreak.None;
                    if(_rowsOnCurrentPage == 31)
                    {
                        this.ReportFooter.PageBreak = PageBreak.None;
                    }
                    else
                    {
                        this.ReportFooter.PageBreak = PageBreak.BeforeBand;
                    }
                        
                }
                   
            }
        }
        
        public SaleInvoiceReport(SaleInvoiceDto dto,string reportName,string imageUrl = "")
        {
            this.LoadLayoutFromXml(reportName);
            if(this.Parameters["DecimalPrecision"]!=null)
            {
                this.Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if(this.Parameters["SubDecimalPrecision"] != null)
            {
                this.Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            var data = ReportExtension.Flatten(dto);
            if(reportName.Contains("D:\\.NetAPI\\Reports\\Accounting\\HD7SaleInvoiceReport.repx"))
            {
                data.ForEach(item =>
                    {
                        item.ItemImage = Path.Combine(imageUrl, "HD7/","item/", item.ItemCode+".jpg");
                    });
            }
            if (reportName.Contains("D:\\.NetAPI\\Reports\\Accounting\\VN7SaleInvoice80Report.repx"))
            {
                this.ReportFooter.CanShrink = true;
            }
            if (reportName.Contains("D:\\.NetAPI\\Reports\\Accounting\\SCSSaleInvoiceA5Report.repx"))
            {
                if (data.Count <= 9)
                {
                    var newLength = 9 - data.Count;
                    for (int i = 0; i < newLength; i++)
                    {
                        data.Add(new FlatInvoiceRow()
                        {
                            Qty = -1,
                            Price = -1,
                            DiscountPercent = -1,
                            Discount = -1,
                            Total = -1,
                        });
                    }
                    this.PageFooter.Visible = false;
                    if(data.Count > 5)
                    {
                        this.xrLine1.Visible = false;
                    }
                }
                else if (data.Count > 9 && data.Count < 26)
                {
                    this.xrLabel7.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel2.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel33.Font = new Font("Khmer OS Content", 10.8f);
                    
                    this.xrLabel26.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel45.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel47.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel32.Font = new Font("Khmer OS Content", 10.8f);

                    this.xrLabel41.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel29.Font = new Font("Khmer OS Content", 10.8f);

                    this.xrLabel28.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel31.Font = new Font("Khmer OS Content", 10.8f);

                    this.xrLabel3.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel4.Font = new Font("Khmer OS Content", 10.8f);
                    
                    this.xrLabel19.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel23.Font = new Font("Khmer OS Content", 10.8f);

                    this.xrLabel22.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel15.Font = new Font("Khmer OS Content", 10.8f);


                    this.xrLabel21.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel5.Font = new Font("Khmer OS Content", 10);

                    // Report Footer
                    this.xrLabel8.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel10.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel13.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel16.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel9.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel17.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel20.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel11.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel18.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel14.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel12.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel14.Width = 150;
                    // Report Footer
                    this.xrLabel48.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel44.TextAlignment = TextAlignment.BottomCenter;

                    this.ReportFooter.PrintAtBottom = true;
                    this.PageFooter.Visible = true;
                    this.xrTable1.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrTable3.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrTableCell6.Font= new Font("Khmer OS Content", 10.8f);
                    //this.ReportHeader.Height = 70;
                    if(data.Count > 23)
                    {
                        this.xrLine1.Visible = false;
                    }
                    

                } else if (data.Count >= 26)
                {
                    this.BeforePrint += Report_BeforePrint;
                    this.Detail.BeforePrint += Detail_BeforePrint;
                    //this.ReportHeader.Height = 70;
                    this.xrLabel7.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel2.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel33.Font = new Font("Khmer OS Content", 10.8f);
                    
                    this.xrLabel26.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel45.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel47.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel32.Font = new Font("Khmer OS Content", 10.8f);

                    this.xrLabel41.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel29.Font = new Font("Khmer OS Content", 10.8f);

                    this.xrLabel28.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel31.Font = new Font("Khmer OS Content", 10.8f);

                    this.xrLabel3.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel4.Font = new Font("Khmer OS Content", 10.8f);
                    
                    this.xrLabel19.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel23.Font = new Font("Khmer OS Content", 10.8f);

                    this.xrLabel22.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel15.Font = new Font("Khmer OS Content", 10.8f);


                    this.xrLabel21.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel5.Font = new Font("Khmer OS Content", 10f);
                    this.xrLabel44.TextAlignment = TextAlignment.BottomCenter;

                    

                    this.xrLabel8.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel10.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel13.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel16.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel9.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel17.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel20.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel11.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel18.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel14.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel12.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrLabel48.Font = new Font("Khmer OS Content", 10.8f);


                                   
                    this.xrLabel14.Width = 150;
                    this.ReportFooter.PrintAtBottom = true;
                    this.PageFooter.Visible = true;
                    this.xrTable1.Font = new Font("Khmer OS Content", 12f);
                    this.xrTable3.Font = new Font("Khmer OS Content", 10.8f);
                    this.xrTableCell6.Font= new Font("Khmer OS Content", 10.8f);
                    this.ReportHeader.HeightF = 100;
                }
            }
                
            //objectDataSource1.DataSource = data;
            //this.DataSource = objectDataSource1;
                this.DataSource = data;
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
            Parameters["TotalRiel"].Value = dto.TotalKHR ==0 ? 
                dto.CurrencySymbol.Equals(ExchangesCurrency.KHR.GetEnumDescription())? dto.TotalMainCurr : dto.TotalSubCurr
                : dto.CurrencySymbol.Equals(ExchangesCurrency.KHR.GetEnumDescription()) ? dto.TotalUSD :dto.TotalKHR;
            Parameters["TotalDollar"].Value = dto.TotalUSD ==0 ? 
                dto.CurrencySymbol.Equals(ExchangesCurrency.USD.GetEnumDescription()) ? dto.TotalMainCurr : dto.TotalSubCurr  
                : dto.CurrencySymbol.Equals(ExchangesCurrency.USD.GetEnumDescription()) ? dto.TotalUSD: dto.TotalKHR;
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
            if(Parameters["CurrencySymbol"] != null)
                Parameters["CurrencySymbol"].Value = dto.CurrencySymbol;
            if (Parameters["SubCurrencySymbol"] != null)
                Parameters["SubCurrencySymbol"].Value = dto.SubCurrencySymbol;
            if (Parameters["DecimalPrecision"] != null)
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            if (Parameters["SubDecimalPrecision"] != null)
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            if (Parameters["Store"] != null)
                Parameters["Store"].Value = dto.Store;

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

        private void SaleInvoiceReport_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
