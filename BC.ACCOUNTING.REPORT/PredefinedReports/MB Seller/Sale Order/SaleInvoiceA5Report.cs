using BC.ACCOUNTING.REPORT.DTO;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order
{
    public partial class SaleInvoiceA5Report : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleInvoiceA5Report()
        {
            InitializeComponent();
        }

        public SaleInvoiceA5Report(SaleInvoiceDto dto, string reportName)
        {
            //this.LoadLayoutFromXml(reportName);
            

        }
    }
}
