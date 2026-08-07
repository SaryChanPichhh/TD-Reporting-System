using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.SaleListing
{
    public partial class SaleListingMovementEVReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleListingMovementEVReport()
        {
            InitializeComponent();
        }
        public SaleListingMovementEVReport(POSSaleListingMovementDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
           
            //CultureInfo.DefaultThreadCurrentCulture = kh;
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
            
        }
    }
}
