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
            if (Parameters["DecimalPrecision"] is not null)
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            
            if (Parameters["SubDecimalPrecision"] is not null)
                Parameters["SubDecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            
            if (Parameters["CurrencySymbol"] is not null)
                Parameters["CurrencySymbol"].Value = dto.CurrencySymbol;
            
            if (Parameters["SubCurrencySymbol"] is not null)
                Parameters["SubCurrencySymbol"].Value = dto.SubCurrencySymbol;
            objectDataSource1.DataSource = dto.CreditNoteFlatten();
        }
    }
}
