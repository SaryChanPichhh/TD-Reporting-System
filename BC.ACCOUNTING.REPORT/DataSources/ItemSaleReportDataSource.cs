using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ItemSaleReportDataSource
    {
        [DisplayName("លេខកូដ")] public string ITEM_CODE { get; set; }
        [DisplayName("ឈ្មោះទំនិញ")] public string ITEM_DESC { get; set; }
        [DisplayName("តម្លៃ​​")] public decimal ITEM_PRICE1 { get; set; }
        [DisplayName("ចំនួន")] public int TOTAL_QUANTITY { get; set; }
        [DisplayName("សរុបរង")] public decimal TOTAL_REVENUE { get; set; }
        [DisplayName("សរុបបញ្ចុះតម្លៃ")] public decimal TOTAL_DISCOUNT { get; set; }
        [DisplayName("សរុបថ្លៃដើម")] public decimal TOTAL_COST { get; set; }
        [DisplayName("ចំណេញ")] public decimal TOTAL_PROFIT { get; set; }
       
        
    }
}
