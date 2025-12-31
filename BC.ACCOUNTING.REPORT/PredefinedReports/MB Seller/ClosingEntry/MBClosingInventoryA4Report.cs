using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.MB;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.ClosingEntry
{
    public partial class MBClosingInventoryA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public MBClosingInventoryA4Report()
        {
            InitializeComponent();
        }
        public MBClosingInventoryA4Report(ClosingInventoryDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            if (Parameters["SubDecimalPrecision"] is not null)
            {
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision;
            }
            if (Parameters["DecimalPrecision"] is not null)
            {
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision;
            }
            objectDataSource1.DataSource = dto;

        }
    }
}
