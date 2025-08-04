using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ItemDataSource
    {
        [DisplayName("លេខកូដទំនិញ")] public string ItemCode { get; set; }
        [DisplayName("ឈ្មោះទំនិញ")] public string ItemDesc { get; set; }
        [DisplayName("រូបទំនិញ")] public string ItemImage { get; set; }
        [DisplayName("ទិន្នន័យបម្លែងឯកតា")] public List<ItemUnit> UnitConvert { get; set; }
    }

    public class ItemUnit
    {
        [DisplayName("ឯកតាស្តុក")] public string UnitStock { get; set; }
        [DisplayName("ចំនួន")] public int Qty { get; set; }
        [DisplayName("តម្លៃ")] public decimal Price { get; set; }
        [DisplayName("សរុប")] public decimal Total { get; set; }
    }
}
