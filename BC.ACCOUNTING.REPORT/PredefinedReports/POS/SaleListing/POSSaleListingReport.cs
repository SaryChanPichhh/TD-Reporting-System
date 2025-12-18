using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.SaleListing
{
    public partial class POSSaleListingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSSaleListingReport()
        {
            InitializeComponent();
        }
        public POSSaleListingReport(POSSaleListingReportDto dto,string reportName)
        {
    

            LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            objectDataSource1.DataSource = dto;

        }
    }
}
