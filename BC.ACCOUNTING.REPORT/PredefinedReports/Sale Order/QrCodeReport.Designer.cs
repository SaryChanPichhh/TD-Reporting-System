namespace BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Order
{
    partial class QrCodeReport
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.objectDataSource2 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Market = new DevExpress.XtraReports.Parameters.Parameter();
            this.Note = new DevExpress.XtraReports.Parameters.Parameter();
            this.TransRef = new DevExpress.XtraReports.Parameters.Parameter();
            this.CustomerTel = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field3 = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field4 = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field5 = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field6 = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field7 = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field8 = new DevExpress.XtraReports.Parameters.Parameter();
            this.Field9 = new DevExpress.XtraReports.Parameters.Parameter();
            this.TransDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.DueDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.Total = new DevExpress.XtraReports.Parameters.Parameter();
            this.Discount = new DevExpress.XtraReports.Parameters.Parameter();
            this.TotalDollar = new DevExpress.XtraReports.Parameters.Parameter();
            this.ExchangeRate = new DevExpress.XtraReports.Parameters.Parameter();
            this.TotalRiel = new DevExpress.XtraReports.Parameters.Parameter();
            this.InvoiceIssuer = new DevExpress.XtraReports.Parameters.Parameter();
            this.CustomerCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.CustomerName = new DevExpress.XtraReports.Parameters.Parameter();
            this.Address = new DevExpress.XtraReports.Parameters.Parameter();
            this.Phone = new DevExpress.XtraReports.Parameters.Parameter();
            this.Seller = new DevExpress.XtraReports.Parameters.Parameter();
            this.IsVisible = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 20F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.DataSource = this.objectDataSource2;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox2});
            this.Detail1.HeightF = 206.3549F;
            this.Detail1.MultiColumn.ColumnCount = 2;
            this.Detail1.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail1.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail1.Name = "Detail1";
            this.Detail1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.Detail1.StylePriority.UsePadding = false;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "ImageUrl", "[ImageData]")});
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(195F, 206.3549F);
            this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // objectDataSource2
            // 
            this.objectDataSource2.DataSource = typeof(global::BC.ACCOUNTING.REPORT.DataSources.ImageItem);
            this.objectDataSource2.Name = "objectDataSource2";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(global::BC.ACCOUNTING.REPORT.Models.FlatInvoiceRow);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xrControlStyle1.Name = "xrControlStyle1";
            this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // Market
            // 
            this.Market.Name = "Market";
            this.Market.Visible = false;
            // 
            // Note
            // 
            this.Note.Description = "Parameter1";
            this.Note.Name = "Note";
            this.Note.Type = typeof(int);
            this.Note.ValueInfo = "0";
            this.Note.Visible = false;
            // 
            // TransRef
            // 
            this.TransRef.Name = "TransRef";
            this.TransRef.Visible = false;
            // 
            // CustomerTel
            // 
            this.CustomerTel.Description = "Parameter1";
            this.CustomerTel.Name = "CustomerTel";
            this.CustomerTel.Visible = false;
            // 
            // Field1
            // 
            this.Field1.AllowNull = true;
            this.Field1.Description = "Parameter1";
            this.Field1.Name = "Field1";
            this.Field1.Visible = false;
            // 
            // Field2
            // 
            this.Field2.AllowNull = true;
            this.Field2.Description = "Parameter2";
            this.Field2.Name = "Field2";
            this.Field2.Visible = false;
            // 
            // Field3
            // 
            this.Field3.AllowNull = true;
            this.Field3.Description = "Parameter3";
            this.Field3.Name = "Field3";
            this.Field3.Visible = false;
            // 
            // Field4
            // 
            this.Field4.AllowNull = true;
            this.Field4.Description = "Parameter4";
            this.Field4.Name = "Field4";
            this.Field4.Visible = false;
            // 
            // Field5
            // 
            this.Field5.AllowNull = true;
            this.Field5.Description = "Parameter5";
            this.Field5.Name = "Field5";
            this.Field5.Visible = false;
            // 
            // Field6
            // 
            this.Field6.AllowNull = true;
            this.Field6.Description = "Parameter6";
            this.Field6.Name = "Field6";
            this.Field6.Visible = false;
            // 
            // Field7
            // 
            this.Field7.AllowNull = true;
            this.Field7.Description = "Parameter7";
            this.Field7.Name = "Field7";
            this.Field7.Visible = false;
            // 
            // Field8
            // 
            this.Field8.AllowNull = true;
            this.Field8.Description = "Parameter8";
            this.Field8.Name = "Field8";
            this.Field8.Visible = false;
            // 
            // Field9
            // 
            this.Field9.AllowNull = true;
            this.Field9.Description = "Parameter9";
            this.Field9.Name = "Field9";
            this.Field9.Visible = false;
            // 
            // TransDate
            // 
            this.TransDate.Name = "TransDate";
            this.TransDate.Type = typeof(global::System.DateTime);
            this.TransDate.ValueInfo = "2025-08-14";
            this.TransDate.Visible = false;
            // 
            // DueDate
            // 
            this.DueDate.Name = "DueDate";
            this.DueDate.Type = typeof(global::System.DateOnly);
            this.DueDate.ValueInfo = "2025-06-18";
            this.DueDate.Visible = false;
            // 
            // Total
            // 
            this.Total.Name = "Total";
            this.Total.Type = typeof(decimal);
            this.Total.ValueInfo = "0";
            this.Total.Visible = false;
            // 
            // Discount
            // 
            this.Discount.Name = "Discount";
            this.Discount.Type = typeof(decimal);
            this.Discount.ValueInfo = "0";
            this.Discount.Visible = false;
            // 
            // TotalDollar
            // 
            this.TotalDollar.Name = "TotalDollar";
            this.TotalDollar.Type = typeof(decimal);
            this.TotalDollar.ValueInfo = "0";
            this.TotalDollar.Visible = false;
            // 
            // ExchangeRate
            // 
            this.ExchangeRate.Name = "ExchangeRate";
            this.ExchangeRate.Type = typeof(decimal);
            this.ExchangeRate.ValueInfo = "0";
            this.ExchangeRate.Visible = false;
            // 
            // TotalRiel
            // 
            this.TotalRiel.Name = "TotalRiel";
            this.TotalRiel.Type = typeof(decimal);
            this.TotalRiel.ValueInfo = "0";
            this.TotalRiel.Visible = false;
            // 
            // InvoiceIssuer
            // 
            this.InvoiceIssuer.Name = "InvoiceIssuer";
            this.InvoiceIssuer.Visible = false;
            // 
            // CustomerCode
            // 
            this.CustomerCode.AllowNull = true;
            this.CustomerCode.Description = "Parameter1";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.AllowNull = true;
            this.CustomerName.Description = "Parameter1";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = false;
            // 
            // Address
            // 
            this.Address.AllowNull = true;
            this.Address.Description = "Parameter1";
            this.Address.Name = "Address";
            this.Address.Visible = false;
            // 
            // Phone
            // 
            this.Phone.AllowNull = true;
            this.Phone.Description = "Parameter1";
            this.Phone.Name = "Phone";
            this.Phone.Visible = false;
            // 
            // Seller
            // 
            this.Seller.AllowNull = true;
            this.Seller.Description = "Parameter1";
            this.Seller.Name = "Seller";
            this.Seller.Visible = false;
            // 
            // IsVisible
            // 
            this.IsVisible.Description = "Parameter1";
            this.IsVisible.Name = "IsVisible";
            this.IsVisible.Type = typeof(bool);
            this.IsVisible.ValueInfo = "False";
            this.IsVisible.Visible = false;
            // 
            // QrCodeReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.Detail,
            this.BottomMargin,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1,
            this.objectDataSource2});
            this.DisplayName = "SCSSaleInvoiceA5Report";
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(5F, 5F, 20F, 20F);
            this.PageHeight = 0;
            this.PageWidth = 400;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom;
            this.ParameterPanelLayoutItems.AddRange(new DevExpress.XtraReports.Parameters.ParameterPanelLayoutItem[] {
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Market, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Note, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.TransRef, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.CustomerTel, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field1, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field2, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field3, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field4, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field5, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field6, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field7, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field8, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Field9, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.TransDate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.DueDate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Total, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Discount, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.TotalDollar, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.ExchangeRate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.TotalRiel, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.InvoiceIssuer, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.CustomerCode, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.CustomerName, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Address, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Phone, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.Seller, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.IsVisible, DevExpress.XtraReports.Parameters.Orientation.Horizontal)});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Market,
            this.Note,
            this.TransRef,
            this.CustomerTel,
            this.Field1,
            this.Field2,
            this.Field3,
            this.Field4,
            this.Field5,
            this.Field6,
            this.Field7,
            this.Field8,
            this.Field9,
            this.TransDate,
            this.DueDate,
            this.Total,
            this.Discount,
            this.TotalDollar,
            this.ExchangeRate,
            this.TotalRiel,
            this.InvoiceIssuer,
            this.CustomerCode,
            this.CustomerName,
            this.Address,
            this.Phone,
            this.Seller,
            this.IsVisible});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "24.2";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox2;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource2;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.Parameters.Parameter Market;
        private DevExpress.XtraReports.Parameters.Parameter Note;
        private DevExpress.XtraReports.Parameters.Parameter TransRef;
        private DevExpress.XtraReports.Parameters.Parameter CustomerTel;
        private DevExpress.XtraReports.Parameters.Parameter Field1;
        private DevExpress.XtraReports.Parameters.Parameter Field2;
        private DevExpress.XtraReports.Parameters.Parameter Field3;
        private DevExpress.XtraReports.Parameters.Parameter Field4;
        private DevExpress.XtraReports.Parameters.Parameter Field5;
        private DevExpress.XtraReports.Parameters.Parameter Field6;
        private DevExpress.XtraReports.Parameters.Parameter Field7;
        private DevExpress.XtraReports.Parameters.Parameter Field8;
        private DevExpress.XtraReports.Parameters.Parameter Field9;
        private DevExpress.XtraReports.Parameters.Parameter TransDate;
        private DevExpress.XtraReports.Parameters.Parameter DueDate;
        private DevExpress.XtraReports.Parameters.Parameter Total;
        private DevExpress.XtraReports.Parameters.Parameter Discount;
        private DevExpress.XtraReports.Parameters.Parameter TotalDollar;
        private DevExpress.XtraReports.Parameters.Parameter ExchangeRate;
        private DevExpress.XtraReports.Parameters.Parameter TotalRiel;
        private DevExpress.XtraReports.Parameters.Parameter InvoiceIssuer;
        private DevExpress.XtraReports.Parameters.Parameter CustomerCode;
        private DevExpress.XtraReports.Parameters.Parameter CustomerName;
        private DevExpress.XtraReports.Parameters.Parameter Address;
        private DevExpress.XtraReports.Parameters.Parameter Phone;
        private DevExpress.XtraReports.Parameters.Parameter Seller;
        private DevExpress.XtraReports.Parameters.Parameter IsVisible;
    }
}
