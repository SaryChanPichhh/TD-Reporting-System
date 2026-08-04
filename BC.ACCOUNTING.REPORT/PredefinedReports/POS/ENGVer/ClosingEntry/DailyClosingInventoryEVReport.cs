using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.DTO.POS;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ENGVer.ClosingEntry
{
    public partial class DailyClosingInventoryEVReport : DevExpress.XtraReports.UI.XtraReport
    {
        private List<PaymentMethodDataSource> Payments { get; set; } = new();
        public DailyClosingInventoryEVReport()
        {
            InitializeComponent();
        }

        public DailyClosingInventoryEVReport(DailyClosingInventoryDto inventoryDto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            this.ReportHeader1.BeforePrint += ReportHeader1_BeforePrint;
            this.Detail2.BeforePrint += Detail2_BeforePrint;
            this.ReportFooter2.BeforePrint += ReportFooter2_BeforePrint;
            this.xrLabel15.BeforePrint += xrLabel15_BeforePrint;
            this.xrLabel16.BeforePrint += xrLabel16_BeforePrint;
            objectDataSource1.DataSource = inventoryDto;
            this.DataSource = objectDataSource1;
            Payments = inventoryDto.Payments;
        }


        private void ReportHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosingInventoryDto;
            e.Cancel = data?.Payments == null || !data.Payments.Any();
        }

        private void Detail2_BeforePrint(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosingInventoryDto;
            e.Cancel = data?.Payments == null || !data.Payments.Any();
        }

        private void ReportFooter2_BeforePrint(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosingInventoryDto;

            if (data == null)
            {
                e.Cancel = true;
                return;
            }

            bool isAllEmpty = string.IsNullOrWhiteSpace(data.Expense.ToString()) &&
                              string.IsNullOrWhiteSpace(data.ExpenseRiel.ToString()) &&
                              string.IsNullOrWhiteSpace(data.ExchangeRate.ToString()) &&
                              string.IsNullOrWhiteSpace(data.Vat.ToString()) &&
                              string.IsNullOrWhiteSpace(data.CashChange);

            e.Cancel = isAllEmpty;
        }
        private void CancelIfPropertyEmpty(object sender, CancelEventArgs e, Func<DailyClosingInventoryDto, string> propertySelector)
        {
            var data = GetCurrentRow() as DailyClosingInventoryDto;

            if (data == null || string.IsNullOrWhiteSpace(propertySelector(data)))
            {
                e.Cancel = true;
            }
        }
        private void xrLabel16_BeforePrint(object sender, CancelEventArgs e)
        {
            CancelIfPropertyEmpty(sender, e, dto => dto.TotalPrice);
        }

        private void xrLabel15_BeforePrint(object sender, CancelEventArgs e)
        {
            CancelIfPropertyEmpty(sender, e, dto => dto.TotalPrice);
        }
    }
}
