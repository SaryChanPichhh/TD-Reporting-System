using BC.ACCOUNTING.REPORT.DTO.POS;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ClosingEntry
{
    public partial class DailyClosingInventoryReport : DevExpress.XtraReports.UI.XtraReport
    {
        private List<PaymentMethodDataSource> Payments { get; set; } = new();
        public DailyClosingInventoryReport()
        {
            InitializeComponent();
        }

        public DailyClosingInventoryReport(DailyClosingInventoryDto inventoryDto, string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = inventoryDto.DecimalPrecision.GetEnumDescription();

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

            bool isAllEmpty = string.IsNullOrWhiteSpace(data.Expense) &&
                              string.IsNullOrWhiteSpace(data.ExpenseRiel) &&
                              string.IsNullOrWhiteSpace(data.ExchangeRate) &&
                              string.IsNullOrWhiteSpace(data.Vat) &&
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
