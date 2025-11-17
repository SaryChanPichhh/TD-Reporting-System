using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class MBSaleListingCustomerDataSource
    {
        public string TransRef { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string? ItemDescKH { get; set; } 
        public int Qty { get; set; }
        public decimal SalePrice { get; set; }
        public string? ConvDesc { get; set; }
        public string? ConvDescKH { get; set; }
        public string? RowNum { get; set; }
        public string? Date { get; set; }
        public string? CategoryCode { get; set; }
        public string? Category { get; set; }
        public string? CategoryKh { get; set; }
        public decimal ExchangeRate { get; set; } = 1;
        public decimal Discount { get; set; } = 0;
        public decimal DiscountOnInvoice { get; set; } = 0;
    }
}