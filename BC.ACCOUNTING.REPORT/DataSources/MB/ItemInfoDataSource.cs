using System;
using System.Collections.Generic;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class ItemInfoDataSource
    {
        public string ItemCode { get; set; }
        public string ItemBarcode { get; set; }
        public string ItemDesc { get; set; }
        public decimal SalePrice { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string CategoryKh { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreateDate { get; set; }
        public List<UnitConvertInfoDataSource> Units { get; set; }

    }
}
