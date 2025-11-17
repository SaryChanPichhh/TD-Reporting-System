using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class PurchaseOrderDataSource 
    {
        public string? Supplier { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? Category { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string? ItemImage { get; set; }
        [Nullable(true)]
        public byte[]? ImageByte { get; set; }
        public int Qty { get; set; }
        public decimal? Cost { get; set; }
        public decimal? ExchangeRate { get; set; } = 0;
    }

   
}
