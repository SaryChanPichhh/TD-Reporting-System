using BC.ACCOUNTING.REPORT.DataSources.RESTAURANT;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO.RESTAURANT
{
    public record RESSaleInventoryDto : ReportDto
    {
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public List<RESSaleInventoryDataSource> Data { get; set; }
        public List<IngredientDataSource> IngredientDataSources { get; set; }
        public List<DiscountOnInvoice>? DiscountOnInvoices { get; set; }
        public string ExchangeSign { get; set; } = "$";
        [Browsable(false)] public Languages? Language { get; set; } = Languages.KM;
        [Browsable(false)] public ReportModes? ReportMode { get; set; } = ReportModes.NormalMode;
    }

    public class DiscountOnInvoice
    {
        public decimal DiscountPrice { get; set; } = 0;
        public decimal ExchangeRate { get; set; } = 0;
    }
}
