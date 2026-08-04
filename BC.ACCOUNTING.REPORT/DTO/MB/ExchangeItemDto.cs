using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
{
    public record ExchangeItemDto : ReportDto
    {
        public string TransRef { get; set; }
        public DateTime TransDate { get; set; }
        public string Seller { get; set; }
        public string Issuer { get; set; }
        public string Market { get; set; }
        public string Store { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTel { get; set; }
        public DateTime DueDate { get; set; }
        public decimal DiscountOnInvoice { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Note { get; set; }
        public decimal TotalUSD { get; set; }
        public decimal TotalKHR { get; set; }
        public List<ExchangeItemDataSource> ReturnItems
        
        { get; set; }

        public List<ExchangeItemDataSource> ReplacementItems { get; set; }
    }
}
