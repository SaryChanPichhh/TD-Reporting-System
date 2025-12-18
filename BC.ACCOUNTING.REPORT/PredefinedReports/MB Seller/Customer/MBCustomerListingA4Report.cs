using BC.ACCOUNTING.REPORT.DTO.MB;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Customer
{
    public partial class MBCustomerListingA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public MBCustomerListingA4Report()
        {
            InitializeComponent();
        }
        public int RowNum { get; set; }
        public MBCustomerListingA4Report(MBCustomersDto ls, string reportName)
        {
            LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
            {
                this.DecimalPrecision.Value = ls.DecimalPrecision.GetEnumDescription();
            }
            if (this.Parameters["SubDecimalPrecision"] is not null)
            {
                this.SubDecimalPrecision.Value = ls.SubDecimalPrecision.GetEnumDescription();
            }
            this.objectDataSource1.DataSource = ls;
        }

        private void GroupHeader1_BeforePrint(object sender ,CancelEventArgs e)
        {
            RowNum += 1;
            xrTableCell2.Text = RowNum.ToString();
        }
    }
}
