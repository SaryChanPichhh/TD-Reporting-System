using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Stock
{
    public partial class InventoryTransactionReportA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public InventoryTransactionReportA4Report()
        {
            InitializeComponent();
        }
        public InventoryTransactionReportA4Report(List<StockModel> data, string reportName, string date)
        {
            this.LoadLayoutFromXml(reportName);
            this.xrTableCellRowNum.BeforePrint += OnBeforePrint;
            objectDataSource1.DataSource = data;
            PRM_DATE.Value = date;
        }
        public int RowNumber { get; set; } = 0;
        private void OnBeforePrint(object sender, CancelEventArgs e)
        {
            var rowNum = (++RowNumber);
            xrTableCellRowNum.Text = rowNum.ToString();
            if (xrTableData is not null)
                xrTableData.BackColor = rowNum % 2 == 0 ? Color.White : Color.WhiteSmoke;

        }
    }
}
