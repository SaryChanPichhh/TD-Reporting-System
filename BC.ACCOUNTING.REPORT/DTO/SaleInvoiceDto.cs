using BC.ACCOUNTING.REPORT.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record SaleInvoiceDto:ReportDto
    {
        [System.ComponentModel.DisplayName("លេខវិក័យប័ត្រ")] public string InvoiceNumber { get; set; }
        [System.ComponentModel.DisplayName("ថ្ងៃចេញវិក័យប័ត្រ")] public DateTime? InvoiceDate { get; set; }
        [System.ComponentModel.DisplayName("អ្នកលក់")] public string Seller { get; set; }
        [System.ComponentModel.DisplayName("អ្នកចេញវិក័យប័ត្រ")] public string InvoicePrinted { get; set; }
        [System.ComponentModel.DisplayName("ថ្ងៃណាត់")] public DateTime? DueDate { get; set; }
        [System.ComponentModel.DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [System.ComponentModel.DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        public string? CustomerTel { get; set; }
        [System.ComponentModel.DisplayName("លេខទូរសព្ទ")] public string? Phone { get; set; }
        [System.ComponentModel.DisplayName("អាស័យដ្ឋាន")] public string? Address { get; set; }
        [System.ComponentModel.DisplayName("ផ្សារ")] public string? Market { get; set; }
        public string? Store { get; set; }
        [System.ComponentModel.DisplayName("សរុប")] public decimal SubTotal { get; set; }
        [System.ComponentModel.DisplayName("បញ្ចុះតម្លៃ")] public decimal Discount { get; set; }
        [System.ComponentModel.DisplayName("អត្រាប្តូរ្របាក់")] public decimal ExchangeRate { get; set; }
        [System.ComponentModel.DisplayName("សរុបដុល្លារ")] public decimal TotalUSD { get; set; }
        [System.ComponentModel.DisplayName("សរុបប្រាក់រៀល")] public decimal TotalKHR { get; set; }
        [System.ComponentModel.DisplayName("សម្គាល់")] public string? Note { get; set; }
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
        [Nullable(true)]
        [Browsable(false)]
        public ExchangesCurrency? CurrencyCode { get; set; } = ExchangesCurrency.USD;
        public string CurrencySymbol => CurrencyCode.GetEnumDescription();
        [DevExpress.Xpo.DisplayName("ទិន្នន័យ")] public List<SaleInvoiceDataSource> Items { get; set; }
        [DevExpress.Xpo.DisplayName("ទិន្នន័យរូបភាព")] public List<ImageItem>? PictureItems { get; set; }

    }

   
    
}
