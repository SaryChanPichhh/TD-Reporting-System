using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AP
{
    public partial class APPaidReport : DevExpress.XtraReports.UI.XtraReport
    {
        public APPaidReport()
        {
            InitializeComponent();
        }
        public APPaidReport(APPaidDto dto,string reportPath)
        {
           LoadLayoutFromXml(reportPath);
           objectDataSource1.DataSource = dto;

           if (Parameters["DecimalPrecision"] is not null)
           {
               this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
           }
           if (Parameters["SubDecimalPrecision"] is not null)
           {
               this.SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
           }
        }
    }
}
