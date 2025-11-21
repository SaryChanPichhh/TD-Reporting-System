using System.ComponentModel;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;
using DevExpress.Office.Utils;
using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class MBSaleListingSummaryDataSource : POSSaleListingSummaryDataSource

    {
        [Browsable(false)]
        [Nullable(true)]
        public decimal DeliveryFee { get; set; } = 0;
    }


}
