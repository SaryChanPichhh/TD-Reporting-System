using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record QuotationDto : ReportDto
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTel { get; set; }
        public string Address { get; set; }
        public decimal DiscountOnInvoice { get; set; }
        public string Note { get; set; }
        public string TransRef { get; set; }
        public DateTime TransDate { get; set; }
        public List<QuotationData> Data { get; set; } = [];
    }

    public class QuotationData
    {
        public string AppName { get; set; } = string.Empty;
        public List<QuotationDataSource> Items { get; set; } = [];
        public List<PackageDetail> PackageDetails { get; set; } = [];
        public DateTime PlanExpiration { get; set; }
        public List<FeatureDataSource> Features { get; set; } = [];
        public List<SoftwareDataSource> Softwares { get; set; } = [];
        public decimal Total { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal TotalRiel { get; set; }
        public decimal Discount { get; set; }
        public decimal BookingPrice
        {
            get;
            set;
        }
        public decimal AmountDollar { get; set; }
        public decimal AmountRiel { get; set; }
    }

    public class PackageDetail
    {
        public string Description { get; set; } =string.Empty; // storage 
        public string Value { get; set; } = string.Empty; // 2gb
    }
}
