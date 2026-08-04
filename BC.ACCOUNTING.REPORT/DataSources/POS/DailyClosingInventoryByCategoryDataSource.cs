using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class DailyClosingInventoryByCategoryDataSource
    {
        [System.ComponentModel.DisplayName("លេខកូដទំនិញ")] public string ItemCode { get; set; }
        [System.ComponentModel.DisplayName("ឈ្មោះទំនិញ")] public string ItemDesc { get; set; }
        [System.ComponentModel.DisplayName("ចំនួន")] public int Qty { get; set; }
        [System.ComponentModel.DisplayName("តម្លៃ")] public decimal Price { get; set; }
        [System.ComponentModel.DisplayName("បញ្ចុះតម្លៃ")] public decimal DiscountPrice { get; set; }
        [System.ComponentModel.DisplayName("សរុបចុងក្រោយ")] public decimal? FinalPrice { get; set; }
        [System.ComponentModel.DisplayName("សរុប")] public decimal Total { get; set; } = 0;
        [Nullable(true)]
        public string? CategoryCode { get; set; } = string.Empty;
        [Nullable(true)]
        public string? CategoryDesc { get; set; } = string.Empty;
    }
}
