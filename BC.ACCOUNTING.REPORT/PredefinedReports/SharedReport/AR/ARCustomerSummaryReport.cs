using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR
{
    public partial class ARCustomerSummaryReport : XtraReport
    {
        public ARCustomerSummaryReport()
        {
            InitializeComponent();
        }
        public ARCustomerSummaryReport(ArCustomerSummaryDto dto,string reportName)
        {
            this.LoadLayoutFromXml(reportName);
            if (GroupHeader1 is not null)
                GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            objectDataSource1.DataSource = dto;
            if (Parameters["DecimalPrecision"] is not null)
                DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            if (Parameters["SubDecimalPrecision"] is not null)
                SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            this.DataSource = objectDataSource1;
        }

        private int _rowIndex = 0;
        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            _rowIndex++;
            xrTableCell1.Text = _rowIndex.ToString();
            if(xrTable1 is not null)
                xrTable1.BackColor = (_rowIndex % 2 == 1)
                    ? Color.White
                    : Color.WhiteSmoke;
        }
    }
}
