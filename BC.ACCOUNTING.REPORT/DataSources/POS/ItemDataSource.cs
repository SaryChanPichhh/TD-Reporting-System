using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class ItemDataSource
    {
        [DisplayName("លេខកូដទំនិញ")] public string ItemCode { get; set; }
        [DisplayName("ឈ្មោះទំនិញ")] public string ItemDesc { get; set; }
        [DisplayName("ចំនួន")] public int Qty { get; set; }
        [DisplayName("តម្លៃ")] public string Price { get; set; }
        [DisplayName("បញ្ចុះតម្លៃ")] public string DiscountPrice { get; set; }
        [DisplayName("សរុបចុងក្រោយ")] public string FinalPrice { get; set; }
        [DisplayName("សរុប")] public string Total { get; set; }
       
    }

  
}
