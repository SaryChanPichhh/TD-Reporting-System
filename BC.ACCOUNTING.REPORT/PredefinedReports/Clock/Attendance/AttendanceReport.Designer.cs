namespace BC.ACCOUNTING.REPORT.PredefinedReports.Clock.Attendance
{
    partial class AttendanceReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.pivotGridField6 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField3 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField7 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField8 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField9 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField10 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField11 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField12 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField4 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField5 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.date = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.Name = "Detail";
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValue.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.Lines.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.25F);
            this.xrPivotGrid1.DataMember = "Data";
            this.xrPivotGrid1.DataSource = this.objectDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.pivotGridField6,
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField7,
            this.pivotGridField8,
            this.pivotGridField9,
            this.pivotGridField10,
            this.pivotGridField11,
            this.pivotGridField12,
            this.pivotGridField4,
            this.pivotGridField5});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OLAPConnectionString = "";
            this.xrPivotGrid1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(980.0001F, 100F);
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(global::BC.ACCOUNTING.REPORT.DTO.Clock.AttendancePivotDto);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField6.AreaIndex = 3;
            this.pivotGridField6.Caption = "ផ្នែក";
            this.pivotGridField6.FieldName = "Position";
            this.pivotGridField6.Name = "pivotGridField6";
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "កូដបុគ្គលិក";
            this.pivotGridField1.FieldName = "EmpCode";
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Caption = "បុគ្គលិក";
            this.pivotGridField2.FieldName = "EmpName";
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField3.AreaIndex = 2;
            this.pivotGridField3.Caption = "វត្តមាន";
            this.pivotGridField3.FieldName = "Attendances";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField7.AreaIndex = 4;
            this.pivotGridField7.Caption = "ច្បាប់";
            this.pivotGridField7.FieldName = "Leaves";
            this.pivotGridField7.Name = "pivotGridField7";
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField8.AreaIndex = 5;
            this.pivotGridField8.Caption = "យឺត";
            this.pivotGridField8.FieldName = "Lates";
            this.pivotGridField8.Name = "pivotGridField8";
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField9.AreaIndex = 6;
            this.pivotGridField9.Caption = "មុន";
            this.pivotGridField9.FieldName = "Tardies";
            this.pivotGridField9.Name = "pivotGridField9";
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField10.AreaIndex = 7;
            this.pivotGridField10.Caption = "ថែមម៉ោង";
            this.pivotGridField10.FieldName = "OverTimes";
            this.pivotGridField10.Name = "pivotGridField10";
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField11.AreaIndex = 8;
            this.pivotGridField11.Caption = "ម៉ោងធ្វើការសរុប";
            this.pivotGridField11.FieldName = "TotalHours";
            this.pivotGridField11.Name = "pivotGridField11";
            // 
            // pivotGridField12
            // 
            this.pivotGridField12.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField12.AreaIndex = 9;
            this.pivotGridField12.Caption = "ថ្ងៃសម្រាក";
            this.pivotGridField12.FieldName = "Holidays";
            this.pivotGridField12.Name = "pivotGridField12";
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField4.AreaIndex = 0;
            this.pivotGridField4.Caption = "កាលបរិច្ឆេទ";
            this.pivotGridField4.FieldName = "Date";
            this.pivotGridField4.Name = "pivotGridField4";
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField5.AreaIndex = 0;
            this.pivotGridField5.Caption = "ថ្ងៃឈប់";
            this.pivotGridField5.FieldName = "Desc";
            this.pivotGridField5.Name = "pivotGridField5";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 65.83331F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[date]")});
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(363.9583F, 34.83331F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(252.0833F, 27.08333F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel2.TextFormatString = "{0:dd-MM-yyyy​​}";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new DevExpress.Drawing.DXFont("Khmer OS Muol Light", 14F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(342.6041F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2F, 2F, 0F, 0F, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(294.7917F, 34.83332F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "របាយការណ៍ស្កេនវត្តមាន";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 0F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // date
            // 
            this.date.Expression = "[FromDate]+\'~\'+[ToDate]";
            this.date.Name = "date";
            // 
            // AttendanceReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.date});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Font = new DevExpress.Drawing.DXFont("Khmer OS Content", 10F);
            this.Margins = new DevExpress.Drawing.DXMargins(10F, 10F, 10F, 10F);
            this.PageWidthF = 1000F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private DetailBand Detail;
        private ReportHeaderBand ReportHeader;
        private ReportFooterBand ReportFooter;
        private XRLabel xrLabel2;
        private XRLabel xrLabel1;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private CalculatedField date;
        private XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField2;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField3;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField4;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField5;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField6;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField7;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField8;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField9;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField10;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField11;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField12;
    }
}
