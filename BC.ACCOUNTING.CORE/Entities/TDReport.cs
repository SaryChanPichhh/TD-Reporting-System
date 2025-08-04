
namespace BC.ACCOUNTING.CORE.Entities
{
    public class TDReport
    {
        public string DbCode { get; set; }
        public string ReportName { get; set; }
        public string ReportType { get; set; } 
        public bool Status { get; set; }
        public string? Connection { get; set; } = "DBConnection";
    }
}
