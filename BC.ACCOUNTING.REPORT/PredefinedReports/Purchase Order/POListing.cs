using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Purchase_Order
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
           

            //  objectDataSource1.DataMember = "Items";
            this.DataSource = objectDataSource1;
            Parameters["StartDate"].Value = dto.StartDate;
            Parameters["EndDate"].Value = dto.EndDate;
        }
        public POListing( string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx

        }
    }
}
