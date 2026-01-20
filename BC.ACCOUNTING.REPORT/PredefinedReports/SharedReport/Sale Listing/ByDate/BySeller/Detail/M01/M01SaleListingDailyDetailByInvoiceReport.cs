using BC.ACCOUNTING.CORE.Entities;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.Sale_Listing.ByDate.BySeller.Detail.M01
{
    public partial class M01SaleListingDailyDetailByInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public M01SaleListingDailyDetailByInvoiceReport()
        {
            InitializeComponent();
        }
        public M01SaleListingDailyDetailByInvoiceReport(List<SaleListingModel> ls, string reportName, SaleListingDto dto)
        {
            LoadLayoutFromXml(reportName);

            //if (Parameters["DecimalPrecision"] != null)
            //    DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();

            //if (Parameters["SubDecimalPrecision"] != null)
            //    SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();

            //if (Parameters["CurrencySymbol"] != null)
            //    CurrencySymbol.Value = string.IsNullOrEmpty(dto.CurrencySymbol) ? "$" : dto.CurrencySymbol;

            //if (Parameters["SubCurrencySymbol"] != null)
            //    SubCurrencySymbol.Value = string.IsNullOrEmpty(dto.SubCurrencySymbol) ? "៛" : dto.SubCurrencySymbol;


            if (reportName.Equals("M01SaleListingDetailBySellerReport"))
            {
                foreach (var header in ls)
                {
                    if (header.SubItems != null && header.SubItems.Any())
                    {
                        header.SubItems = header.SubItems
                            .GroupBy(x => new
                            {
                                x.ItemCode,
                                ConvFromDesc = x.ConvFromDesc ?? string.Empty
                            })
                            .Select(g => new MOSubItemDataSource
                            {
                                ItemCode = g.Key.ItemCode,
                                ConvFromDesc = g.Key.ConvFromDesc,

                                ItemDesc = g.First().ItemDesc,
                                UnitConvCode = g.First().UnitConvCode,

                                Qty = g.Sum(x => x.Qty),
                                ItemCost = g.Sum(x => x.ItemCost),
                                SalePrice = g.Sum(x => x.SalePrice)
                            })
                            .ToList();
                    }
                }

                objectDataSource1.DataSource = ls;
            }

            objectDataSource1.DataSource = ls;
            prm_EndDate.Value = string.IsNullOrWhiteSpace(dto.Date2) ? dto.Prd2 : dto.Date2;
            prm_StartDate.Value = string.IsNullOrWhiteSpace(dto.Date1) ? dto.Prd1 : dto.Date1;
            //if (prm_StartDate?.Value != null && string.IsNullOrEmpty(dto.Date1) && string.IsNullOrEmpty(dto.Prd1))
            //{
            //    if (xrLabel13 is not null && xrLabel8 is not null)
            //        xrLabel8.Visible = xrLabel13.Visible = false;
            //}

            //if (prm_EndDate?.Value != null && string.IsNullOrEmpty(dto.Date2) && string.IsNullOrEmpty(dto.Prd2))
            //{
            //    if (xrLabel13 is not null && xrLabel14 is not null)
            //        xrLabel14.Visible = xrLabel13.Visible = false;
            //}

            //prm_CompanyName.Value = dto.CompanyName;
            //try
            //{
            //    if (xrTableCell2 != null)
            //    {
            //        if (GroupHeader4 != null)
            //        {
            //            GroupHeader4.BeforePrint -= GroupHeader1_BeforePrint;
            //            GroupHeader4.BeforePrint += GroupHeader1_BeforePrint;
            //        }
            //        if (GroupHeader2 != null)
            //        {
            //            GroupHeader2.BeforePrint -= GroupHeader2_BeforePrint;
            //            GroupHeader2.BeforePrint += GroupHeader2_BeforePrint;
            //        }
            //        if (GroupHeader3 != null)
            //        {
            //            GroupHeader3.BeforePrint -= GroupHeader3_BeforePrint;
            //            GroupHeader3.BeforePrint += GroupHeader3_BeforePrint;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private int groupIndex = 0;
        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            groupIndex++;
            xrTableCell222.Text = groupIndex.ToString();
            if (xrTable2 is not null)
                xrTable2.BackColor = groupIndex % 2 == 0 ? Color.WhiteSmoke : Color.White;
        }
        private void GroupHeader2_BeforePrint(object sender, CancelEventArgs e)
        {
            groupIndex = 0;
        }
        private void GroupHeader3_BeforePrint(object sender, CancelEventArgs e)
        {
            groupIndex = 0;
        }
    }
}
