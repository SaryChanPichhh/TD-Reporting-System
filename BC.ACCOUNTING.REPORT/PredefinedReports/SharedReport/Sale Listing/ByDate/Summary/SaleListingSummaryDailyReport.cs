using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.CORE.DTO.SaleListing;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Data.Helpers;
using DevExpress.XtraReports.UI;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.Sale_Listing.ByDate.Summary
{
    public partial class SaleListingSummaryDailyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleListingSummaryDailyReport()
        {
            InitializeComponent();
        }
        public SaleListingSummaryDailyReport(List<SaleListingModel> ls, string reportName, SaleListingDto dto)
        {
           
            LoadLayoutFromXml(reportName);
          
            if(Parameters["DecimalPrecision"] != null)
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();

            if (Parameters["SubDecimalPrecision"] != null)
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();

            if(Parameters["CurrencySymbol"] != null)
                Parameters["CurrencySymbol"].Value = dto.CurrencySymbol;

            if (Parameters["SubCurrencySymbol"] != null)
                Parameters["SubCurrencySymbol"].Value = dto.SubCurrencySymbol;

            objectDataSource1.DataSource = ls;
            prm_EndDate.Value = string.IsNullOrWhiteSpace(dto.Date2) ? dto.Prd2 : dto.Date2;
            prm_StartDate.Value = string.IsNullOrWhiteSpace(dto.Date1) ? dto.Prd1 : dto.Date1;
            if (prm_StartDate?.Value != null && string.IsNullOrEmpty(dto.Date1)&&string.IsNullOrEmpty(dto.Prd1))
            {
                if (xrLabel13 is not null &&xrLabel8 is not null)
                    xrLabel8.Visible = xrLabel13.Visible = false;
            }

            if (prm_EndDate?.Value != null && string.IsNullOrEmpty(dto.Date2)&&string.IsNullOrEmpty(dto.Prd2))
            {
                if(xrLabel13 is not null && xrLabel14 is not null)
                    xrLabel14.Visible = xrLabel13.Visible = false;
            }

            prm_CompanyName.Value = dto.CompanyName;
            try
            {
                if (xrTableCell2 != null)
                {
                    if (GroupHeader1 != null)
                    {
                        GroupHeader1.BeforePrint -= GroupHeader1_BeforePrint;
                        GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
                    }
                    if (GroupHeader2 != null)
                    {
                        GroupHeader2.BeforePrint -= GroupHeader2_BeforePrint;
                        GroupHeader2.BeforePrint += GroupHeader2_BeforePrint;
                    }
                    if (GroupHeader3 != null)
                    {
                        GroupHeader3.BeforePrint -= GroupHeader3_BeforePrint;
                        GroupHeader3.BeforePrint += GroupHeader3_BeforePrint;
                    }
                }
                
            }
            catch (Exception ex)
            {
            }
            
        }
        private int groupIndex = 0;
        private int secondIndex = 0;
        private int thirdIndex = 0;
        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            groupIndex++;
            xrTableCell2.Text = groupIndex.ToString();
            secondIndex = 0;
            if (xrTable2 is not null)
                xrTable2.BackColor = groupIndex %2 == 0 ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
        }
        private void GroupHeader2_BeforePrint(object sender, CancelEventArgs e)
        {
            secondIndex++;
            groupIndex = 0;
            thirdIndex = 0;
        }
        private void GroupHeader3_BeforePrint(object sender, CancelEventArgs e)
        {
            thirdIndex++;
            secondIndex = 0;
            groupIndex = 0;

        }
    }
}
