using BC.ACCOUNTING.CORE.DTO.AR;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AP
{
    public partial class APReport : DevExpress.XtraReports.UI.XtraReport
    {
        public APReport()
        {
            InitializeComponent();
        }
        public APReport(List<Aging> dto,string reportName,string companyName)
        {
            LoadLayoutFromXml(reportName);
            this.objectDataSource1.DataSource = dto;
            CompanyName.Value =companyName;
        }
    }
}
