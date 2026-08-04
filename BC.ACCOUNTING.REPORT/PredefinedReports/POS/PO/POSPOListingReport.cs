namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.PO
{
    public partial class POSPOListingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSPOListingReport()
        {
            InitializeComponent();
        }
        public POSPOListingReport(POSPOListingDto dto,string reportPath)
        {
            LoadLayoutFromXml(reportPath);
            objectDataSource1.DataSource = dto;
            if (Parameters["DecimalPrecision"] is not null)
            {
                DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if (Parameters["SubDecimalPrecision"] is not null)
            {
                SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
        }
    }
}
