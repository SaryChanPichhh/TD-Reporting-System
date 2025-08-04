using System.Data.Entity.Core.Common;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ArReportDTO
    {
        public required string DbCode { get; set; }
        public required string ByDate { get; set; }
        public required string FromAcc { get; set; }
        public required string ToAcc { get; set; }
        public required string AccType { get; set; }
        public required string FromAnal { get; set; }
        public required string ToAnal { get; set; }
        public required string T0 { get; set; }
        public required string T1 { get; set; }
        public required string T2 { get; set; }
        public required string T3 { get; set; }
        public required string T4 { get; set; }
        public required string T5 { get; set; }
        public required string T6 { get; set; }
        public required string T7 { get; set; }
        public required string T8 { get; set; }
        public required string T9 { get; set; }
    }
}
