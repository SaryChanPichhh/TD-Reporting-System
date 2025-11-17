using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.MB;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Listing
{
    public partial class MBSaleInvoiceSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public MBSaleInvoiceSummaryReport()
        {
            InitializeComponent();
        }
        public MBSaleInvoiceSummaryReport(MBSaleInvoiceSummaryDto dto , string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            if(GroupHeader1 is not null)
                GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            if(Detail is not null)
                Detail.BeforePrint += Detail_BeforePrint;

        }
        public int RowNum { get; set; } = 0;
        private void GroupHeader1_BeforePrint(object sender,CancelEventArgs e)
        {
            RowNum = 0;
        }
        private void Detail_BeforePrint(object sender,CancelEventArgs e)
        {
            RowNum++;
            Console.WriteLine(RowNum);
            xrTableRow3.BackColor = RowNum % 2 == 0 ? Color.WhiteSmoke : Color.White;

        }


    }
}
