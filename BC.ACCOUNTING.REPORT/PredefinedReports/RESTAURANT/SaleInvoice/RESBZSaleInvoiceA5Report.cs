using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.SaleInvoice
{
    public partial class RESBZSaleInvoiceA5Report : DevExpress.XtraReports.UI.XtraReport
    {
        public RESBZSaleInvoiceA5Report()
        {
            InitializeComponent();
        }
        
        public RESBZSaleInvoiceA5Report(RESBZSaleInvoiceDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
        }

    }
}
