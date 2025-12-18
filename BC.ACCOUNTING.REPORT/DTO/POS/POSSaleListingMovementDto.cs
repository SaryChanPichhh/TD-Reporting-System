using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper.Enums;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record POSSaleListingMovementDto:ReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PrintDate { get; set; }
        public string ShopName { get; set; }
        public string ShopImage { get; set; }
        [Browsable(false)]
        public Languages? Language { get; set; } = Languages.KM;
        public List<POSSaleIistingInventoryDataSource> Items { get; set; }

    }
}
