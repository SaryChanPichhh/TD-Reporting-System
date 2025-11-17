using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.Audit
{
    public partial class RESSaleAuditWithProfitA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        public RESSaleAuditWithProfitA4Report()
        {
            InitializeComponent();
        }


        public RESSaleAuditWithProfitA4Report(RESSaleInventoryDto dto,string reportPath)
        {
            LoadLayoutFromXml(reportPath);
            var data = dto.Data.GroupBy(x => new { x.MenuName,x.SalePrice,x.TotalDiscountPrice,x.TotalCost,x.ExchangeRate })
                .Select(x=> new RESSaleInventoryDataSource
                {
                    MenuName = x.Key.MenuName,
                    SalePrice = x.Key.SalePrice,
                    TotalDiscountPrice = x.Key.TotalDiscountPrice,
                    TotalCost = x.Key.TotalCost*x.Sum(y=>y.Quantity),
                    ExchangeRate = x.Key.ExchangeRate,
                    Quantity = x.Sum(y=>y.Quantity),
                    IngredientDataSources = x.SelectMany(y=>y.IngredientDataSources).GroupBy(z=>z.Ingredient).Select(z=> new IngredientDataSource
                    {
                        Ingredient = z.Key,
                        Quantity = z.Sum(a=>a.Quantity),
                        Cost = z.Sum(a=>a.Cost)
                    }).ToList(),
                    IngredientAddOnDataSources = x.SelectMany(y => y.IngredientAddOnDataSources).GroupBy(z => z.Ingredient).Select(z => new IngredientDataSource
                    {
                        Ingredient = z.Key,
                        Quantity = z.Sum(a => a.Quantity),
                        Cost = z.Sum(a => a.Cost)
                    }).ToList(),
                })
                .ToList();

            dto.Data = data;
            objectDataSource1.DataSource = dto;

        }

        private void RESSaleInventoryWithProfitA4Report_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
