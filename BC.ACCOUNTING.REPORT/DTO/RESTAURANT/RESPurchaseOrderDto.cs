
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.Helper;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESPurchaseOrderDto : ReportDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PrintDate { get; set; }
        public string ShopName { get; set; }
        public string? ShopImage { get; set; }
        public string? Checker { get; set; }
        public DateTime? CheckDate { get; set; }
        public string? ExchangeSign { get; set; } 
        public string? Note { get; set; }
        public string? Description { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? ReceiveBy { get; set; }
        public string? Warehouse { get; set; }
        public string? Supplier { get; set; }
        public string?Code { get; set; }
        public List<PurchaseOrderDataSource> Items { get; set; }
        public string? Field1 { get; set; } = string.Empty;
        public string? Field2 { get; set; } = string.Empty;
        public string? Field3 { get; set; } = string.Empty;
        public string? Field4 { get; set; } = string.Empty;
        public string? Field5 { get; set; } = string.Empty;
        public string? Field6 { get; set; } = string.Empty;
        public string? Field7 { get; set; } = string.Empty;
        public string? Field8 { get; set; } = string.Empty;
        public string? Field9 { get; set; } = string.Empty;

    }
}
