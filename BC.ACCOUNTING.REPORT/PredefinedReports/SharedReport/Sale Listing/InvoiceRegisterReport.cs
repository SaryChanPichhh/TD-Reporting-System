using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.CORE.DTO.SaleListing;
using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.Sale_Listing
{
    public partial class InvoiceRegisterReport : DevExpress.XtraReports.UI.XtraReport
    {
        private int counter = 0;
        public InvoiceRegisterReport()
        {
            InitializeComponent();
        }

        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            counter++;
            //xrTableCell9.Text = counter.ToString();
        }
        public InvoiceRegisterReport(List<SaleListingModel> ls, SaleListingDto dto, string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = ls;
            if (prm_StartDate == null || prm_EndDate == null)
            {
                prm_StartDate = new DevExpress.XtraReports.Parameters.Parameter();
                prm_EndDate = new DevExpress.XtraReports.Parameters.Parameter();
            }
            prm_EndDate.Value = string.IsNullOrWhiteSpace(dto.Date2) ? dto.Prd2 : dto.Date2;
            prm_StartDate.Value = string.IsNullOrWhiteSpace(dto.Date1) ? dto.Prd1 : dto.Date1;
            prm_CompanyName.Value = dto.CompanyName;
            GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
        }
    }
}
