using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class InvoiceItemDataSource
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public List<UnitConvertDataSource> UnitConvert { get; set; } = new();
        public string? RowNum { get; set; }
        public decimal SubTotal { get; set; }
    }
    public class UnitConvertDataSource
    {
        public string UnitStock { get; set; }
        public string Note { get; set; } = string.Empty;
    
        public bool IsNoteVisible => !string.IsNullOrWhiteSpace(Note);
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public List<ExtraInvoiceItemDataSource> Extra { get; set; } = new();
        public List<ComboItemDataSource> Combo { get; set; } = new();
    }
    public class ComboItemDataSource
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string UnitStock { get; set; }
        public int Qty { get; set; }
    }
    public class ExtraInvoiceItemDataSource
    {   
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public List<ExtraItemUnitConvertDataSource> UnitConvert { get; set; } = new();
    }

    public class ExtraItemUnitConvertDataSource
    {
        public string UnitStock { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}

