using System;
using System.Collections.Generic;
using BC.ACCOUNTING.CORE.DTO.SaleListing;
using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Listing
{
    public partial class SaleListingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleListingReport()
        {
            InitializeComponent();
        }
        public SaleListingReport(List<SaleListingModel> ls, string reportName, SaleListingDto dto)
        {
            LoadLayoutFromXml(reportName);
            
            objectDataSource1.DataSource = ls;
            prm_EndDate.Value = dto.Date2 is null or ""?dto.Prd2:dto.Date2;
            prm_StartDate.Value = dto.Date1 is null or ""?dto.Prd1:dto.Date1;
        }
    }
}
