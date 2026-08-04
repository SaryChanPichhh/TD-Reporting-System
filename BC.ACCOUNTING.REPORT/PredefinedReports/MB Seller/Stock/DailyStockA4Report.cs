using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Stock
{
    public partial class DailyStockA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public DailyStockA4Report()
        {
            InitializeComponent();
        }
        public DailyStockA4Report(List<StockModel> data,string reportName,string date)
        {
            this.LoadLayoutFromXml(reportName);
            this.xrTableCellRowNum.BeforePrint += OnBeforePrint;
            objectDataSource1.DataSource = data;
            PRM_DATE.Value = date;
        }

        public int RowNumber { get; set; } = 0;
        private void OnBeforePrint(object sender, CancelEventArgs e)
        {
            var rowNum = (++RowNumber);
            xrTableCellRowNum.Text = rowNum.ToString();
            if(xrTableData is not null)
                xrTableData.BackColor = rowNum%2==0? Color.White: Color.WhiteSmoke;

        }

        private List<StockModel> GroupByLocationAndItemCode(List<StockModel> data)
        {
            return data.GroupBy(x => new { x.Location, x.ItemCode } )
                .Select(x=> new StockModel
                {
                    Location = x.Key.Location,
                    ItemCode = x.Key.ItemCode,
                    CreditNote = x.Sum(x=>x.CreditNote),
                    OpeningInventory = x.Sum(x=>x.OpeningInventory),
                    PurchaseOrder = x.Sum(x=>x.PurchaseOrder),
                    Transfer = x.Sum(x=>x.Transfer),
                    Sale = x.Sum(x=>x.Sale),
                    InventoryAdjustment = x.Sum(x=>x.InventoryAdjustment),
                }).ToList();
        }
        private List<StockModel> GroupByLocationAndDate(List<StockModel> data)
        {
            return data.GroupBy(x => new { x.Location, x.MovDate,x.ItemCode})
                .Select(x => new StockModel
                {
                    Location = x.Key.Location,
                    MovDate = x.Key.MovDate,
                    ItemCode = x.Key.ItemCode,
                    CreditNote = x.Sum(x => x.CreditNote),
                    OpeningInventory = x.Sum(x => x.OpeningInventory),
                    PurchaseOrder = x.Sum(x => x.PurchaseOrder),
                    Transfer = x.Sum(x => x.Transfer),
                    Sale = x.Sum(x => x.Sale),
                    InventoryAdjustment = x.Sum(x => x.InventoryAdjustment),
                }).ToList();
        }
    }
}