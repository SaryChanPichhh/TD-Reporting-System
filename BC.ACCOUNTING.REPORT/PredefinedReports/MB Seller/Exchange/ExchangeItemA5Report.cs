using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Exchange
{
    public partial class ExchangeItemA5Report : DevExpress.XtraReports.UI.XtraReport
    {
        public ExchangeItemA5Report()
        {
            InitializeComponent();
        }
        public ExchangeItemA5Report(ExchangeItemDto dto,string reportName)
        {
            
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }
    }
}
