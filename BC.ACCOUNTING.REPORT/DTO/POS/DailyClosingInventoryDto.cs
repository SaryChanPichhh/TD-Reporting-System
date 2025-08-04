using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT;
using BC.ACCOUNTING.REPORT.DataSources.POS;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record DailyClosingInventoryDto:ReportDto
    {
        [DisplayName("អ្នកលក់")] public string Seller { get; set; }
        [DisplayName("ថ្ងៃ")] public string Dates { get; set; }
        [DisplayName("ថ្ងៃព្រីន")] public DateTime PrintDate { get; set; }
        [DisplayName("រយពេល")] public string Duration { get; set; }
        [DisplayName("សរុបរង")] public string Subtotal { get; set; }
        [DisplayName("បញ្ចុះតម្លៃលើវិក្កយបត្រ")] public string Discount { get; set; }
        [DisplayName("សរុបវិក្កយបត្រ")]  public string TotalPrice { get; set; }
        [DisplayName("សរុបរៀល")] public string TotalRiel { get; set; }
        [DisplayName("សរុបដុល្លារ")] public string TotalDollar { get; set; }
        [DisplayName("ចំណាយ")] public string Expense { get; set; }
        [DisplayName("ចំណាយរៀល")] public string ExpenseRiel { get; set; }
        [DisplayName("អត្រាប្តូរប្រាក់")] public string ExchangeRate { get; set; }
        [DisplayName("ពន្ធ")] public string Vat { get; set; }
        [DisplayName("ប្រាក់អាប់")] public string CashChange { get; set; }
      
        public List<ItemDataSource> Items { get; set; }  
        public List<PaymentMethodDataSource> Payments { get; set; }  
        //public List<ExpenseDataSource> Expenses { get; set; }  
    }
}
