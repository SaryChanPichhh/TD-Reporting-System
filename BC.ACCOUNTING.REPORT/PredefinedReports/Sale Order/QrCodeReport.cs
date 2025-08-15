using System;
using System.Collections.Generic;
using System.Diagnostics;
using BC.ACCOUNTING.REPORT.DTO;
using Microsoft.AspNetCore.Authentication;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Order
{
    public partial class QrCodeReport : DevExpress.XtraReports.UI.XtraReport
    {
        public QrCodeReport()
        {
            InitializeComponent();
            Console.WriteLine(this.objectDataSource2);
        }
    }
}
