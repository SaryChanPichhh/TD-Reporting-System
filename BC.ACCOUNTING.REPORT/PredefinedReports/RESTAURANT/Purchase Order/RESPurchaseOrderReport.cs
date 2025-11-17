using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;
using BC.ACCOUNTING.REPORT.Helper;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.Purchase_Order
{
    public partial class RESPurchaseOrderReport : XtraReport
    {
        public RESPurchaseOrderReport()
        {
            InitializeComponent();
        }

        public RESPurchaseOrderReport(RESPurchaseOrderDto dto, string reportName)
        {
            // use .repx file instead of InitializeComponent
            this.LoadLayoutFromXml(reportName);

            objectDataSource.DataSource = dto;
            this.DataSource = objectDataSource;

            this.Detail.BeforePrint += Detail_BeforePrint;

            // attach handlers only if groups exist
            if (this.Bands[BandKind.GroupHeader] != null)
            {
                if (this.GroupHeader1 != null)
                    this.GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;

                if (this.GroupHeader2 != null)
                    this.GroupHeader2.BeforePrint += GroupHeader2_BeforePrint;
            }
        }

        public int Index { get; set; } = 0;   // detail row counter
        public int RowNum { get; set; } = 0;  // group counter

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            var itemCode = GetCurrentColumnValue("ItemCode")?.ToString();
            if (!string.IsNullOrEmpty(itemCode))
            {
                Index++;
                xrTableCell2.Text = Index.ToString();
            }
            else
            {
                xrTableCell2.Text = string.Empty;
            }
        }

        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            RowNum++;
            xrTableCell2.Text = RowNum.ToString();

            // reset detail index for each group
            Index = 0;
        }

        private void GroupHeader2_BeforePrint(object sender, CancelEventArgs e)
        {
            // reset group numbering
            RowNum = 0;
        }

        private void RESPurchaseOrderReport_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}