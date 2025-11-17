using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record PurchaseOrderDto: ReportDto
    {
        [DisplayName("កាលបរិច្ឆេទទទួល")] public DateTime ReceiveDate { get; set; }
        [DisplayName("អ្នកទទូល")] public string ReceiveBy { get; set; }
        [DisplayName("ឃ្លាំង")] public string Warehouse { get; set; }
        [DisplayName("លេខយោង")] public string FootNote { get; set; }
        [DisplayName("លេខកូដ")] public string Code { get; set; }
        [DisplayName("បរិយាយ")] public string Description { get; set; }
        [DisplayName("អត្រាប្តូរប្រាក់")] public decimal ExchangeRate { get; set; } = 0;
        [DisplayName("សរុបរង")] public decimal SubTotal { get; set; }
        [DisplayName("សរុប")] public decimal Total { get; set; }
        [DisplayName("អ្នកផ្គត់ផ្គង")] public string Supplier { get; set; }
        [DisplayName("អ្នកត្រួតពិនិត្យ")] public string Checker { get; set; }
        [DisplayName("កាលបរិច្ឆេទពិនិត្យ")] public string CheckDate { get; set; }
        [DisplayName("ទិន្នន័យ")] public List<ItemDataSource> Items { get; set; }
        public string CurrencySymbol { get; set; } = "$";

    }
}
