using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;
using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.English.Audit
{
    public partial class RESSaleAuditWithProfitA4EngReport : XtraReport
    {
        public RESSaleAuditWithProfitA4EngReport()
        {
            InitializeComponent();
        }

        //public RESSaleAuditWithProfitA4EngReport(
        //    RESSaleInventoryDto dto,
        //    string reportPath)
        //{
        //    InitializeComponent();
        //    LoadLayoutFromXml(reportPath);

        //    BuildData(dto);
        //}

        //protected void BuildData(RESSaleInventoryDto dto)
        //{
        //    var data = dto.Data
        //        .GroupBy(x => new
        //        {
        //            x.MenuName,
        //            x.SalePrice,
        //            x.TotalDiscountPrice,
        //            x.TotalCost,
        //            x.ExchangeRate
        //        })
        //        .Select(x => new RESSaleInventoryDataSource
        //        {
        //            MenuName = x.Key.MenuName,
        //            SalePrice = x.Key.SalePrice,
        //            TotalDiscountPrice = x.Key.TotalDiscountPrice,
        //            TotalCost = x.Key.TotalCost * x.Sum(y => y.Quantity),
        //            ExchangeRate = x.Key.ExchangeRate,
        //            Quantity = x.Sum(y => y.Quantity),

        //            IngredientDataSources = x
        //                .SelectMany(y => y.IngredientDataSources ?? Enumerable.Empty<IngredientDataSource>())
        //                .GroupBy(z => z.Ingredient)
        //                .Select(z => new IngredientDataSource
        //                {
        //                    Ingredient = z.Key,
        //                    Quantity = z.Sum(a => a.Quantity),
        //                    Cost = z.Sum(a => a.Cost)
        //                })
        //                .ToList(),

        //            IngredientAddOnDataSources = x
        //                .SelectMany(y => y.IngredientAddOnDataSources ?? Enumerable.Empty<IngredientDataSource>())
        //                .GroupBy(z => z.Ingredient)
        //                .Select(z => new IngredientDataSource
        //                {
        //                    Ingredient = z.Key,
        //                    Quantity = z.Sum(a => a.Quantity),
        //                    Cost = z.Sum(a => a.Cost)
        //                })
        //                .ToList()
        //        })
        //        .ToList();

        //    dto.Data = data;
        //    objectDataSource1.DataSource = dto;
        //}
    }
}
