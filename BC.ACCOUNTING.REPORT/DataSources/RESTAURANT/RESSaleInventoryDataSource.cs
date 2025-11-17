using System;
using System.Collections.Generic;

namespace BC.ACCOUNTING.REPORT.DataSources.RESTAURANT
{
    public class RESSaleInventoryDataSource
    {
        public string MenuName { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalDiscountPrice { get; set; }
        public List<IngredientDataSource> IngredientDataSources { get; set; }
        public List<IngredientDataSource> IngredientAddOnDataSources { get; set; }
        public decimal? ExchangeRate { get; set; } = 1;
    }
    public class IngredientDataSource
    {
        public string Ingredient { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
