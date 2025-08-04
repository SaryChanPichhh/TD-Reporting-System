using BC.ACCOUNTING.REPORT.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO
{
    
    public record InvoiceReportDto: ReportDto
    {
        [DisplayName("ទិន្នន័យ")] public  List<ItemSaleReportDataSource> Items { get; set; }

        [DisplayName("ថ្ងៃចាប់ផ្តើម")] public required DateTime start_date { get; set; }
        [DisplayName("ថ្ងៃបញ្ចប់")] public required DateTime end_date { get; set; }
        [DisplayName("ឈ្មោះហាង")] public string shopName { get; set; }
        [DisplayName("រូបភាពហាង")] public string shopImage { get; set; }

       
    }
}
