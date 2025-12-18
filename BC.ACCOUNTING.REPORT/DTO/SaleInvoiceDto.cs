using BC.ACCOUNTING.REPORT.DataSources;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;


namespace BC.ACCOUNTING.REPORT.DTO
{
    public record SaleInvoiceDto:ReportDto
    {
        [DisplayName("លេខវិក័យប័ត្រ")] public string InvoiceNumber { get; set; }
        [DisplayName("ថ្ងៃចេញវិក័យប័ត្រ")] public DateTime? InvoiceDate { get; set; }
        [DisplayName("អ្នកលក់")] public string Seller { get; set; }
        [DisplayName("អ្នកចេញវិក័យប័ត្រ")] public string InvoicePrinted { get; set; }
        [DisplayName("ថ្ងៃណាត់")] public DateTime? DueDate { get; set; }
        [DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        public string? CustomerTel { get; set; }
        [DisplayName("លេខទូរសព្ទ")] public string? Phone { get; set; }
        [DisplayName("អាស័យដ្ឋាន")] public string? Address { get; set; }
        [DisplayName("ផ្សារ")] public string? Market { get; set; }
        public string? Store { get; set; }
        [DisplayName("សរុប")] public decimal SubTotal { get; set; }
        [DisplayName("បញ្ចុះតម្លៃ")] public decimal Discount { get; set; }
        [DisplayName("អត្រាប្តូរ្របាក់")] public decimal ExchangeRate { get; set; }
        [DisplayName("សរុបដុល្លារ")] public decimal TotalUSD { get; set; }
        [DisplayName("សរុបប្រាក់រៀល")] public decimal TotalKHR { get; set; }
        public decimal TotalMainCurr { get; set; } = 0;
        public decimal TotalSubCurr { get; set; } = 0;
        [DisplayName("សម្គាល់")] public string? Note { get; set; }
        public bool IsShow { get; set; } = true;
        public string? BookPrice { get; set; }
        public string? DuePrice { get; set; }
        public string? Field1 { get; set; }
        public string? Field2 { get; set; }
        public string? Field3 { get; set; }
        public string? Field4 { get; set; }
        public string? Field5 { get; set; }
        public string? Field6 { get; set; }
        public string? Field7 { get; set; }
        public string? Field8 { get; set; }
        public string? Field9 { get; set; }
        [DisplayName("ទិន្នន័យ")] public List<SaleInvoiceDataSource> Items { get; set; }
        [DisplayName("ទិន្នន័យរូបភាព")] public List<ImageItem>? PictureItems { get; set; }

    }

   
    
}
