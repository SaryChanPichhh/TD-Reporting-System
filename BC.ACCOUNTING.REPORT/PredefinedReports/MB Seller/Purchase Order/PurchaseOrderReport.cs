using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Purchase_Order
{
    public partial class PurchaseOrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PurchaseOrderReport()
        {
            InitializeComponent();
        }
        public PurchaseOrderReport(PurchaseOrderDto dto)
        {
            InitializeComponent();
            var data = ReportExtension.Flatten(dto);
            objectDataSource.DataSource = data;
            this.DataSource = objectDataSource;

        }
        public PurchaseOrderReport(PurchaseOrderDto dto, string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
            var data = ReportExtension.Flatten(dto);
            objectDataSource.DataSource = data;
            this.DataSource = objectDataSource;
            // Assign values to parameters

            Parameters["ReceiveDate"].Value = dto.ReceiveDate;
            Parameters["ReceiveBy"].Value = dto.ReceiveBy;
            Parameters["Warehouse"].Value = dto.Warehouse;
            Parameters["FootNote"].Value = dto.FootNote;
            Parameters["Code"].Value = dto.Code;
            Parameters["Description"].Value = dto.Description;
            Parameters["ExchangeRate"].Value = dto.ExchangeRate;
            Parameters["SubTotal"].Value = dto.SubTotal;
            Parameters["Total"].Value = dto.Total;
            Parameters["Supplier"].Value = dto.Supplier;
            Parameters["Checker"].Value = dto.Checker;
            Parameters["CheckDate"].Value = dto.CheckDate;
            Parameters["TotalRiel"].Value = dto.ExchangeRate * dto.Total;
            Parameters["CurrencySymbol"].Value = dto.CurrencySymbol;

        }
        public PurchaseOrderReport(string report)
        {
            this.LoadLayoutFromXml(report); //use this instead of InitializeComponent when use with file .repx
        }

        
    }
}
