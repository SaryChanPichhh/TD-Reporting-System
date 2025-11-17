using System.ComponentModel;
using System.Globalization;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.SaleInvoice
{
    public partial class RESSaleInvoice80Report : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleInvoice80Report()
        {
            
            InitializeComponent();
        } 
        public RESSaleInvoice80Report(RESSaleInvoiceDto dto,string reportName)
        {
            var kh = CultureInfo.GetCultureInfo("km-KH");
            
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }

        private void xrPanel1_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
