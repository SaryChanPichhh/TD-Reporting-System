namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Quotation
{
    public partial class QuotationA5Report : XtraReport
    {
        public QuotationA5Report()
        {
            InitializeComponent();
        }

        public QuotationA5Report(QuotationDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            if (this.Parameters["SubDecimalPrecision"] is not null)
                this.SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
