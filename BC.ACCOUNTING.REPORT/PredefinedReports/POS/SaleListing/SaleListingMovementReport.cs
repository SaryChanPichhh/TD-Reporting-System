using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.POS;
using System.Globalization;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.SaleListing
{
    public partial class SaleListingMovementReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleListingMovementReport()
        {
            InitializeComponent();
        }
        public SaleListingMovementReport(POSSaleListingMovementDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
           
            //CultureInfo.DefaultThreadCurrentCulture = kh;
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
            
        }
    }
}
