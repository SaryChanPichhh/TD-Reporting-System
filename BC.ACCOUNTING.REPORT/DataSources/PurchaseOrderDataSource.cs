using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class PurchaseOrderDataSource
    {
        [Description("លេខកូដទំនិញ")] public string ItemCode { get; set; }
        [Description("ឈ្មោះទំនិញ")] public string ItemDesc { get; set; }
        [Description("រូបទំនិញ")] public string ItemImage { get; set; }
        [Description("ទិន្នន័យបម្លែងឯកតា")] public List<ItemUnit> UnitConvert { get; set; }
    }

   
}
