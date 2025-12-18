using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Listing
{
    public partial class MBIncomeAndExpenseA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public MBIncomeAndExpenseA4Report()
        {
            InitializeComponent();
        }
        public MBIncomeAndExpenseA4Report(IncomeExpenseDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] != null)
            {
                this.Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if(this.Parameters["SubDecimalPrecision"] != null)
            {
                this.Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            this.objectDataSource1.DataSource = dto;
        }
    }
}
