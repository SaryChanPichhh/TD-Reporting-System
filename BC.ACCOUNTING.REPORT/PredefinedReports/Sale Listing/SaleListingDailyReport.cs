using System;
using BC.ACCOUNTING.CORE.DTO.SaleListing;
using BC.ACCOUNTING.CORE.Entities;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Listing
{
    public partial class SaleListingDailyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleListingDailyReport()
        {
            InitializeComponent();
        }
        public SaleListingDailyReport(List<SaleListingModel> ls, string reportName, SaleListingDto dto)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = ls;
            prm_EndDate.Value = string.IsNullOrWhiteSpace(dto.Date2) ? dto.Prd2 : dto.Date2;
            prm_StartDate.Value = string.IsNullOrWhiteSpace(dto.Date1) ? dto.Prd1 : dto.Date1;
            prm_CompanyName.Value = dto.CompanyName;
            try
            {
                GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            }
            catch (Exception ex)
            {
            }
            
        }
        int groupIndex = 0;
        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            groupIndex++;
            xrTableCell2.Text = groupIndex.ToString();
            Console.WriteLine($"Group Index: {groupIndex}"); // For debugging purposes
        }
    }
}
