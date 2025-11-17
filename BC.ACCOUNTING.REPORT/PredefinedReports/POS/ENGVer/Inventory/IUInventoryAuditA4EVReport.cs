using System.ComponentModel;
using System.Diagnostics;
using BC.ACCOUNTING.REPORT.DTO.POS;
using DevExpress.XtraReports.UI;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.Inventory
{
    public partial class IUInventoryAuditA4EVReport : XtraReport
    {
        public IUInventoryAuditA4EVReport()
        {
            InitializeComponent();
        }

        public IUInventoryAuditA4EVReport(InventoryDto dto, string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource1.DataSource = dto;
            if(GroupHeader1 is not null)
                GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;

        }

        public int RowNum { get; set; } = 0;
        public void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            RowNum++;
            if (xrTableCell2 is not null)
                xrTableCell2.Text = (RowNum).ToString();
            Debug.WriteLine(RowNum);
        }
        public void GroupHeader2_BeforePrint(object sender, CancelEventArgs e)
        {
            RowNum=0;
        }
    }
}