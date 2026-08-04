using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BC.ACCOUNTING.REPORT.DTO.Clock;
using BC.ACCOUNTING.REPORT.DataSources.Clock;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.Clock.Attendance
{
    public partial class AttendanceReport : XtraReport
    {
        public AttendanceReport()
        {
            InitializeComponent();
        }
        public AttendanceReport(AttendanceDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            var data = ToPivotDto(dto);
            objectDataSource1.DataSource = data;
            this.DataSource = objectDataSource1;
            
            // Apply font family
            this.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", this.Font?.Size ?? 9.75F, this.Font?.Style ?? DevExpress.Drawing.DXFontStyle.Regular);
            ApplyKhmerFont(this.Bands);
        }

        public static AttendancePivotDto ToPivotDto(AttendanceDto source)
        {
            var dataList = new List<AttendancePivotDataSource>();

            if (source.Data != null)
            {
                foreach (var emp in source.Data)
                {
                    if (emp.AbsenceDates != null && emp.AbsenceDates.Any())
                    {
                        dataList.AddRange(emp.AbsenceDates.Select(date => new AttendancePivotDataSource
                        {
                            Position = emp.Position,
                            EmpCode = emp.EmpCode,
                            EmpName = emp.EmpName,
                            Attendances = emp.Attendances,
                            Leaves = emp.Leaves,
                            Absences = emp.Absences,
                            Lates = emp.Lates,
                            Tardies = emp.Tardies,
                            OverTimes = emp.OverTimes,
                            TotalHours = emp.TotalHours,
                            Holidays = emp.Holidays,
                            Date = date.Date,
                            Desc = date.Desc == 1 ? "អវត្តមាន" : (date.Desc == 0 ? "" : date.Desc.ToString())
                        }));
                    }
                    else
                    {
                        dataList.Add(new AttendancePivotDataSource
                        {
                            Position = emp.Position,
                            EmpCode = emp.EmpCode,
                            EmpName = emp.EmpName,
                            Attendances = emp.Attendances,
                            Leaves = emp.Leaves,
                            Absences = emp.Absences,
                            Lates = emp.Lates,
                            Tardies = emp.Tardies,
                            OverTimes = emp.OverTimes,
                            TotalHours = emp.TotalHours,
                            Holidays = emp.Holidays,
                            Date = source.FromDate,
                            Desc = ""
                        });
                    }
                }
            }

            return new AttendancePivotDto
            {
                PrintDate = source.PrintDate,
                FromDate = source.FromDate,
                ToDate = source.ToDate,
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
                    foreach (DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field in pivotGrid.Fields)
                    {
                        if (field.FieldName == "Desc")
                        {
                            field.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
                        }
                    }

                    pivotGrid.FieldValueDisplayText += (s, e) => {
                        if (e.ValueType.ToString() == "GrandTotal")
                        {
                            e.DisplayText = "សរុប";
                        }
                    };

                    pivotGrid.CustomCellValue += (s, e) => {
                        if (e.DataField != null && e.DataField.FieldName == "Desc")
                        {
                            if (e.RowValueType != DevExpress.XtraPivotGrid.PivotGridValueType.Value ||
                                e.ColumnValueType != DevExpress.XtraPivotGrid.PivotGridValueType.Value)
                            {
                                e.Value = "";
                            }
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
