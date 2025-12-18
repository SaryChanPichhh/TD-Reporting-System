using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ArCustomerPaidReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        public ArCustomerPaidReceipt()
        {
            InitializeComponent();
        }
        public ArCustomerPaidReceipt(ArCustomerPaidDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            if(this.Parameters["DecimalPrecision"]!=null)
            {
                this.Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if(this.Parameters["SubDecimalPrecision"]!=null)
            {
                this.Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;
        }
    }
}
