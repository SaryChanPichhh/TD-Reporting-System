using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class POListingDataSource
    {
        [DisplayName("ថ្ងៃទទួល")] public DateTime ReceiveDate { get; set; }
        public List<POList> Items { get; set; }
    }

    public class POList
    {
        [DisplayName("ពេលវេលា")] public string Time { get; set; }
        [DisplayName("ឃ្លាំង")] public string Warehouse { get; set; }
        [DisplayName("លេខកូដអ្នកផ្គត់ផ្គង់")] public string SupplierCode { get; set; }
        [DisplayName("ឈ្មោះអ្នកផ្គត់ផ្គង់")] public string SupplierName { get; set; }
        [DisplayName("ឈ្មោះអ្នកផ្គត់ផ្គង់ខ្មែរ")] public string SupplierNameKH { get; set; }
        [DisplayName("លេខយោង")] public string Footnote { get; set; }
        [DisplayName("លេខកូដ")] public string ItemCode { get; set; }
        [DisplayName("ឈ្មោះទំនិញ")] public string ItemDesc { get; set; }
        [DisplayName("ឈ្មោះទំនិញខ្មែរ")] public string? ItemDescKH { get; set; }
        [DisplayName("ខ្នាត")] public string? PurchUnit { get; set; }
        [DisplayName("ចំនួន")] public int Qty { get; set; }
        [DisplayName("តម្លៃ")] public decimal Cost { get; set; }
        [DisplayName("តម្លៃសរុប")] public decimal TotalCost { get; set; }
        [DisplayName("ឯកតាស្តុក")] public string UnitDesc { get; set; }
        public decimal ExchangeRate { get; set; } = 1;
    }
}
