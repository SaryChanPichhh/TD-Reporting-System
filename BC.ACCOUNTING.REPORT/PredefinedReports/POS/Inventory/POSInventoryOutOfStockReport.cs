using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Inventory
{
    public partial class POSInventoryOutOfStockReport : DevExpress.XtraReports.UI.XtraReport
    {
        public POSInventoryOutOfStockReport()
        {
            InitializeComponent();
        }
        public POSInventoryOutOfStockReport(POSItemDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource.DataSource = dto;
        }
    }
}
