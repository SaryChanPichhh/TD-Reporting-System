using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class DailyClosing80DataSource
    {
        [System.ComponentModel.DisplayName("លេខកូដទំនិញ")] public object ItemCode { get; set; }
        [System.ComponentModel.DisplayName("ឈ្មោះទំនិញ")] public string ItemDesc { get; set; }
        [System.ComponentModel.DisplayName("ចំនួន")] public object Qty { get; set; }
        [System.ComponentModel.DisplayName("តម្លៃ")] public object Price { get; set; }
        [System.ComponentModel.DisplayName("បញ្ចុះតម្លៃ")] public object DiscountPrice { get; set; }
        [System.ComponentModel.DisplayName("សរុបចុងក្រោយ")] public object? FinalPrice { get; set; }
        [System.ComponentModel.DisplayName("សរុប")] public object? Total { get; set; } 
        [Nullable(true)]
        public object? CategoryCode { get; set; }
        [Nullable(true)]
        public string? CategoryDesc { get; set; }

    }
}
