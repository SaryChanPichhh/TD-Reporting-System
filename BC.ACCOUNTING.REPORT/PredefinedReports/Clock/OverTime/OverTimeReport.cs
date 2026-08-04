using BC.ACCOUNTING.REPORT.DataSources.Clock;
using BC.ACCOUNTING.REPORT.DTO.Clock;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Clock.OverTime
{
    public partial class OverTimeReport : DevExpress.XtraReports.UI.XtraReport
    {
        public OverTimeReport()
        {
            InitializeComponent();
        }
        public OverTimeReport(OverTimeDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            var data = ToPivotDto(dto);
            objectDataSource1.DataSource = data;
            this.DataSource = objectDataSource1;
            
            // Apply font family
            this.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", this.Font?.Size ?? 9.75F, this.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
            ApplyKhmerFont(this.Bands);
        }
        public static OverTimePivotDto ToPivotDto(OverTimeDto source)
        {
            var dataList = new List<OverTimePivotDataSource>();

            if (source.Data != null)
            {
                foreach (var emp in source.Data)
                {
                    if (emp.Data != null && emp.Data.Any())
                    {
                        dataList.AddRange(emp.Data.Select(date => new OverTimePivotDataSource
                        {
                            EmpCode = emp.EmpCode,
                            EmpName = emp.EmpName,
                            Department = emp.Department,
                            Date = date.Date,
                            OverTime = date.OverTime
                        }));
                    }
                    else if (emp.Dates != null && emp.Dates.Any())
                    {
                        dataList.AddRange(emp.Dates.Select(date => new OverTimePivotDataSource
                        {
                            EmpCode = emp.EmpCode,
                            EmpName = emp.EmpName,
                            Department = emp.Department,
                            Date = date,
                            OverTime = 1.0
                        }));
                    }
                }
            }

            return new OverTimePivotDto
            {
                PrintDate = source.PrintDate,
                Data = dataList
            };
        }

        private void ApplyKhmerFont(BandCollection bands)
        {
            foreach (Band band in bands)
            {
                if (band.Font != null)
                {
                    band.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", band.Font.Size, band.Font.Style);
                }
                ApplyKhmerFont(band.Controls);
            }
        }

        private void ApplyKhmerFont(XRControlCollection controls)
        {
            foreach (XRControl control in controls)
            {
                if (control.Font != null)
                {
                    control.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", control.Font.Size, control.Font.Style);
                }
                if (control is XRPivotGrid pivotGrid)
                {
                    pivotGrid.FieldValueDisplayText += (s, e) => {
                        if (e.ValueType.ToString() == "GrandTotal")
                        {
                            e.DisplayText = "ចំនួនសរុប";
                        }
                    };
                    pivotGrid.Appearance.Cell.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.Cell.Font?.Size ?? 8.25F, pivotGrid.Appearance.Cell.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                    pivotGrid.Appearance.CustomTotalCell.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.CustomTotalCell.Font?.Size ?? 8.25F, pivotGrid.Appearance.CustomTotalCell.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                    pivotGrid.Appearance.FieldHeader.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.FieldHeader.Font?.Size ?? 8.25F, pivotGrid.Appearance.FieldHeader.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                    pivotGrid.Appearance.FieldValue.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.FieldValue.Font?.Size ?? 8.25F, pivotGrid.Appearance.FieldValue.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                    pivotGrid.Appearance.FieldValueGrandTotal.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.FieldValueGrandTotal.Font?.Size ?? 8.25F, pivotGrid.Appearance.FieldValueGrandTotal.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                    pivotGrid.Appearance.FieldValueTotal.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.FieldValueTotal.Font?.Size ?? 8.25F, pivotGrid.Appearance.FieldValueTotal.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                    pivotGrid.Appearance.GrandTotalCell.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.GrandTotalCell.Font?.Size ?? 8.25F, pivotGrid.Appearance.GrandTotalCell.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                    pivotGrid.Appearance.Lines.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.Lines.Font?.Size ?? 8.25F, pivotGrid.Appearance.Lines.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                    pivotGrid.Appearance.TotalCell.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", pivotGrid.Appearance.TotalCell.Font?.Size ?? 8.25F, pivotGrid.Appearance.TotalCell.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
                }
                if (control.Controls != null && control.Controls.Count > 0)
                {
                    ApplyKhmerFont(control.Controls);
                }
            }
        }
    }
}
