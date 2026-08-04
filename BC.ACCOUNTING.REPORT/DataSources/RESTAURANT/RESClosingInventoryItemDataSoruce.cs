using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources.RESTAURANT
{
    public class RESClosingInventoryItemDataSoruce
    {
        [DisplayName("លេខកូដទំនិញ")] public string ItemCode { get; set; }
        [DisplayName("ឈ្មោះទំនិញ")] public string ItemDesc { get; set; }
        [DisplayName("ចំនួន")] public int Qty { get; set; }
        [DisplayName("តម្លៃ")] public string Price { get; set; }
        [DisplayName("តម្លៃ")] public string DiscountPrice { get; set; }
        [DisplayName("សរុប")] public string Total { get; set; } = string.Empty;

    }
}
