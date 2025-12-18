using System;
using System.Collections.Generic;
using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record MBCustomersDto : ReportDto
    {
        public DateTime PrintDate { get; set; }
        public List<MBCustomerDataSource> Customers { get; set; }
    }
}
