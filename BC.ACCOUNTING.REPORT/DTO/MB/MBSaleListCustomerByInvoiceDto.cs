using System;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using DevExpress.CodeParser;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public class CustomerDto
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerNameKH { get; set; }
        public string CustomerPhone { get; set; }
        public string? Store { get; set; } 
        public string? RoadNo { get; set; }
        public string? HouseNo { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Commune { get; set; }
        public string? AreaName { get; set; } 
        public string? AreaNameKH { get; set; }
        public string? MarketName { get; set; }
        public string? MarketNameKH { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public List<MBSaleListingCustomerDataSource> Items { get; set; } = new List<MBSaleListingCustomerDataSource>();

    }
}
