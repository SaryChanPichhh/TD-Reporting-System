using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AP
{
    public partial class APSupplierSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public APSupplierSummaryReport()
        {
            InitializeComponent();
        }
        public APSupplierSummaryReport(APCustomerSummaryDto dto , string reportPath)
        {
            LoadLayoutFromXml(reportPath);
            
            objectDataSource1.DataSource = dto;
            if (Parameters["DecimalPrecision"] is not null)
            {
                DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if (Parameters["SubDecimalPrecision"] is not null)
            {
                SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            }

            Console.WriteLine(DecimalPrecision.Value);
        }
    }
}
