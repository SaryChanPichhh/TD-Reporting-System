using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.MB;

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
            this.objectDataSource1.DataSource = dto;
        }
    }
}
