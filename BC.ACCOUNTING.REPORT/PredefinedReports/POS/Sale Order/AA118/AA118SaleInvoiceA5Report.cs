using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Sale_Order.AA118
{
    public partial class AA118SaleInvoiceA5Report : DevExpress.XtraReports.UI.XtraReport
    {
        private const int FooterBreakThreshold = 16;
        private const int FullPageRowLimit = 20;

        private int _rowCount = 0;
        private bool _firstBreakDone = false;

        public AA118SaleInvoiceA5Report()
        {
            InitializeComponent();
        }

        public AA118SaleInvoiceA5Report(POSSaleInvoiceDto dto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);

            if (Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();

            objectDataSource1.DataSource = dto;
            this.DataSource = objectDataSource1;

            // Wire up the Detail band event to handle page-break logic.
            this.Detail.BeforePrint += Detail_BeforePrint;
        }
        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            _rowCount++;

            int threshold = _firstBreakDone ? FullPageRowLimit : FooterBreakThreshold;

            if (_rowCount >= threshold)
            {
                Detail.PageBreak = PageBreak.AfterBand;
                _rowCount = 0;
                _firstBreakDone = true;
            }
            else
            {
                Detail.PageBreak = PageBreak.None;
            }
        }
    }
}
