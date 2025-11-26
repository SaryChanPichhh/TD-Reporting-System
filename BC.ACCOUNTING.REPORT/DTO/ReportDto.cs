using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Runtime.Serialization;
using BC.ACCOUNTING.REPORT.Helper;
using BC.ACCOUNTING.REPORT.Models;
using BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR;
using DevExpress.CodeParser;
using DevExpress.Xpo;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ReportDto
    {

        [Browsable(false)]
        public string ReportName { get; set; }
        [Browsable(false)]
        public Export? ExportFormat { get; set; } = null; 
        [Browsable(false)] public string? Connection { get; set; } = "Default";
        [Browsable(false)][Nullable(true)] public bool IsAutoPrint { get; set; } = false;
        [Browsable(false)][Nullable(true)] public string? PrinterName { get; set; } = "XP-80C";

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            ReportHelper.IsAutoPrint = IsAutoPrint;
            ReportHelper.PrinterName = PrinterName;
            ReportHelper.ReportName = ReportName;
        }

    }
}
