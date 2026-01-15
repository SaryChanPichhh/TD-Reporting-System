using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DataSources.POS;
using DevExpress.Xpo;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DTO.POS
{
    public record POSPOListingDto : ReportDto
    {
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        [Nullable(true)][Browsable(false)] public Languages? Language { get; set; } = Languages.KM;
        public List<POSPOListingDataSource> Orders { get; set; }
    }
}
