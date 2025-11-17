using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Purchase_Order.SCS
{
    public partial class PurchaseOrderInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PurchaseOrderInvoiceReport()
        {
            InitializeComponent();
        }
        
        public PurchaseOrderInvoiceReport(RESPurchaseOrderDto dto,string reportName)
        {

            LoadLayoutFromXml(reportName);
            objectDataSource.DataSource = dto;

            this.DataSource = objectDataSource;
            if (GroupHeader1 is not null)
                this.GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            
            if(GroupHeader2 is not null)
                this.GroupHeader2.BeforePrint += GroupHeader_BeforePrint;
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
