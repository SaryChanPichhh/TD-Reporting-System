using System;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class MBPurchaseOrderDataSource : ItemDataSource
    {
        public string InvoiceNumber { get; set; }
        public string Warehouse { get; set; }
        public string Branch { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
