using System.ComponentModel;
namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Inventory
{
    public partial class IUInventoryAuditA4Report : XtraReport
    {
        public IUInventoryAuditA4Report()
        {
            InitializeComponent();
        }

        public IUInventoryAuditA4Report(InventoryDto dto, string reportName,bool isUseBarcode = false)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource1.DataSource = dto;
            if(GroupHeader1 is not null)
                GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            if (this.Parameters["IsUseBarcode"] is not null)
                this.IsUseBarcode.Value = isUseBarcode;

        }

        public int RowNum { get; set; } = 0;
        public void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            RowNum++;
            if (xrTableCell2 is not null)
                xrTableCell2.Text = (RowNum).ToString();
            xrTableRow6.BackColor = RowNum % 2 == 0 ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
        }
        public void GroupHeader2_BeforePrint(object sender, CancelEventArgs e)
        {
            RowNum=0;
        }
    }
}