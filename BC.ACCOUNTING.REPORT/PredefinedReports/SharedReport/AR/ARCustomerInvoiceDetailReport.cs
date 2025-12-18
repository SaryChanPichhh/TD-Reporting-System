using BC.ACCOUNTING.REPORT.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ARCustomerInvoiceDetailReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ARCustomerInvoiceDetailReport()
        {
            InitializeComponent();
        }
        public ARCustomerInvoiceDetailReport(ARCustomerInvoiceDetailDto dto, string reportName)
        { 
            LoadLayoutFromXml(reportName);
            if (Parameters["DecimalPrecision"] != null)
            {
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if (Parameters["SubDecimalPrecision"] != null)
            {
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            this.objectDataSource1.DataSource = dto;
        }
    }
}
