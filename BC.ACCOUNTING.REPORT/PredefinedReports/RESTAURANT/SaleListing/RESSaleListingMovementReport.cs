using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.SaleListing
{
    public partial class RESSaleListingMovementReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleListingMovementReport()
        {
            InitializeComponent();
        }
        public RESSaleListingMovementReport(RESSaleListingMovementDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource1.DataSource = dto;
        }

    }
}
