using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ArCustomerReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerReceipt()
        {
            InitializeComponent();
        }

        public ArCustomerReceipt(ArCustomerDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            if(this.Parameters["DecimalPrecision"] != null)
            {
                this.Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if(this.Parameters["SubDecimalPrecision"] != null)
            {
                this.Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            this.DataSource = objectDataSource1;
        }
    }
}
