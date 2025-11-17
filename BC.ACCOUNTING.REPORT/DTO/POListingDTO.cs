using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record POListingDTO :ReportDto
    {
       
        [DisplayName("ថ្ងៃចាប់ផ្តើម")] public required DateTime StartDate { get; set; }
        [DisplayName("ថ្ងៃបញ្ចប់")] public required DateTime EndDate { get; set; }
        [DisplayName("ទិន្នន័យ")] public List<POListingDataSource> Orders { get; set; }
        public string CurrencySymbol { get; set; } = "$";
    }
}
