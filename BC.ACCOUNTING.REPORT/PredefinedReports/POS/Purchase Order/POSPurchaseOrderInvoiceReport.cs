using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Purchase_Order
{
    public partial class POSPurchaseOrderInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSPurchaseOrderInvoiceReport()
        {
            InitializeComponent();
        }
        
        public POSPurchaseOrderInvoiceReport(RESPurchaseOrderDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource.DataSource = dto;

            this.DataSource = objectDataSource;
            if (GroupHeader1 != null)
            {
                this.GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            }
            if (GroupHeader2 != null)
            {
                this.GroupHeader2.BeforePrint += GroupHeader_BeforePrint;
            }
           
            
        }
        private void GroupHeader_BeforePrint(object sender, CancelEventArgs e)
        {
            RowNum = 0;
        }
        public int RowNum { get; set; } = 0;
        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            RowNum++;
            xrTableCell2.Text = RowNum.ToString();
        }
    }
}
