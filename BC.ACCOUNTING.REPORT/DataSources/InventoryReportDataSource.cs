using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class InventoryReportDataSource
    {
        [DisplayName("ឃ្លាំងទំនិញ")] public string LOCATION { get; set; }
        [DisplayName("លេខកូដ")] public string ITEM_CODE { get; set; }
        [DisplayName("ឈ្មោះទំនិញ")] public string ITEM_DESC { get; set; }
        [DisplayName("ឈ្មោះទំនិញខ្មែរ")] public string ITEM_CUS10_KH { get; set; }
        [DisplayName("ខ្នាត")] public string UNIT_STOCK { get; set; }
        [DisplayName("ដើមគ្រា")] public int PHYSICAL { get; set; }
        [DisplayName("លក់")] public int ON_ORDER { get; set; }
        [DisplayName("ក្នុងស្តុក")] public int TOTAL { get; set; }
        [DisplayName("រូបទំនិញ")] public string ITEM_IMAGE { get; set; }
        [DisplayName("ទិន្នន័យខ្នាតទំនិញ")] public List<UnitConversion> UNIT_CONV { get; set; }
    }
}
