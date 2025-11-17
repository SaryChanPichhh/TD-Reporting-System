using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.CreditNote
{
    public partial class CreditNoteReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CreditNoteReport()
        {
            InitializeComponent();
        }
        public CreditNoteReport(CreditNoteDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto.CreditNoteFlatten();
        }
    }
}
