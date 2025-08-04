using BC.ACCOUNTING.REPORT.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Inventory
{
    public partial class InventoryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InventoryReport()
        {
            InitializeComponent();
        }
        public InventoryReport(InventoryReportDto dto, string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
            objectDataSource.DataSource = dto.Items;
            this.DataSource = objectDataSource;
        }
        public InventoryReport(string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
        }
    }
}
