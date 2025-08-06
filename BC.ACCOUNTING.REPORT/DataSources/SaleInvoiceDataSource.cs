using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class SaleInvoiceDataSource:ItemDataSource
    {
        [DisplayName("បញ្ចុះតម្លៃ")] public decimal Discount { get; set; }
        [DisplayName("បញ្ចុះតម្លៃ%")] public decimal DiscountPercent { get; set; }
    }
  
}
