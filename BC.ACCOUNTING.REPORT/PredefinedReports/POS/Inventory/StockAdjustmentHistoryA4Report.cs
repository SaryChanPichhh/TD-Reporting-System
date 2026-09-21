
namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.Inventory
{
    public partial class StockAdjustmentHistoryA4Report : XtraReport
    {
        public StockAdjustmentHistoryA4Report()
        {
            InitializeComponent();
        }
        public StockAdjustmentHistoryA4Report(AdjustmentHistoryDto dto,string reportName,bool isUseBarcode)
        {
            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            dto.Items.ForEach(x=>
                Console.WriteLine(x.Cost)
                );
        }
    }
}
