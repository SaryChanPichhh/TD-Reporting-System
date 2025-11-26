using System;
using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Purchase_Order
{
    public partial class POListing : DevExpress.XtraReports.UI.XtraReport
    {
        public POListing()
        {
            InitializeComponent();
        }
        public POListing(POListingDTO dto, string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
           // var data = ReportExtension.Flatten(dto);
            objectDataSource1.DataSource = dto;
            Parameters["StartDate"].Value = dto.StartDate;
            Parameters["EndDate"].Value = dto.EndDate;
            if (StartDate.Value.Equals(DateTime.MinValue) && EndDate.Value.Equals(DateTime.MinValue))
            {
                xrLabel3.Visible = false;
                xrLabel5.Visible = false;
                xrLabel6.Visible = false;
            }

            //  objectDataSource1.DataMember = "Items";
            this.DataSource = objectDataSource1;
            
        }
        public POListing( string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx

        }
    }
}
