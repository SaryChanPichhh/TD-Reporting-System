using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ArCustomerPaidDto:ReportDto
    {
        [DisplayName("ក្រុមហ៊ុន")] public string Company { get; set; }
        [DisplayName("លេខបង្កាន់ដៃ")] public string RecieptNo { get; set; }
        [DisplayName("វិក្កយបត្រ")] public string TransRef { get; set; }
        [DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("ទឹកប្រាក់")] public string TransValue { get; set; }
        [DisplayName("ចំនួនទូទាត់")] public string Amount { get; set; }
        public string Paid { get; set; } = string.Empty;
        public string Discount { get; set; } = string.Empty;
        [DisplayName("ចំនួនជាពាក្យ")] public string AmountLetter { get; set; }
        [DisplayName("នៅសល់")] public string Balance { get; set; }
        [DisplayName("វិធីសាស្រ្តទូទាត់")] public string PaymentMethod { get; set; }
        [DisplayName("ចំណាំ")] public string Note { get; set; }

    }
}
