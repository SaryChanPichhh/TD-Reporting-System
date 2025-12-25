using System.Diagnostics.CodeAnalysis;
using BC.ACCOUNTING.CORE.DTO.General;

namespace BC.ACCOUNTING.CORE.DTO.SaleListing
{
    public class SaleListingDto :ReportDTO
    {
        public string CompanyName { get; set; }
        public string DbCode { get; set; }
        public string? Code1 { get; set; }
        public string? Code2 { get; set; }
        public string? Loc1 { get; set; } = string.Empty;
        public string? Loc2 { get; set; } = string.Empty;
        public string? Item1 { get; set; } = string.Empty;
        public string? Item2 { get; set; } = string.Empty;
        public string? Ref1 { get; set; } = string.Empty;
        public string? Ref2 { get; set; } = string.Empty;
        [AllowNull]
        public string? Prd1 { get; set; } = string.Empty;
        [AllowNull]
        public string? Prd2 { get; set; } = string.Empty;
        [AllowNull]
        public string? Date1 { get; set; } = string.Empty;
        [AllowNull]
        public string? Date2 { get; set; } = string.Empty;
        public string? VoidStatus { get; set; } = "N";
        public string? HeaderRecType { get; set; } =  "O";
        public List<string>? HeaderRecTypes { get; set; } = new ();
        public string? DetailRecType { get; set; } = "D";
        public string? AnalM0 { get; set; } = string.Empty;
        public string? AnalM1 { get; set; } = string.Empty;
        public string? AnalM2 { get; set; } = string.Empty;
        public string? AnalM3 { get; set; } = string.Empty;
        public string? AnalM4 { get; set; } = string.Empty;
        public string? AnalM5 { get; set; } = string.Empty;
        public string? AnalM6 { get; set; } = string.Empty;
        public string? AnalM7 { get; set; } = string.Empty;
        public string? AnalM8 { get; set; } = string.Empty;
        public string? AnalM9 { get; set; } = string.Empty;
        public string? AnalysisType { get; set; } = string.Empty;
    }
}
