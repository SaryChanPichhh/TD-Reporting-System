using System;
using System.Collections.Generic;
using BC.ACCOUNTING.CORE.DTO.SaleListing;
using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Listing
{
    public partial class SaleListingProfitPerInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleListingProfitPerInvoiceReport()
        {
            InitializeComponent();
        }
        //public SaleListingProfitPerInvoiceReport(List<SaleListingModel> ls, string reportName, SaleListingDto dto)
        //{
        //    LoadLayoutFromXml(reportName);

        //    objectDataSource1.DataSource = ls;
        //    prm_EndDate.Value = string.IsNullOrWhiteSpace(dto.Date2)?dto.Prd2:dto.Date2;
        //    prm_StartDate.Value = string.IsNullOrWhiteSpace(dto.Date1) ? dto.Prd1 : dto.Date1;
        //    prm_CompanyName.Value = dto.CompanyName;
        //}
    }
}
