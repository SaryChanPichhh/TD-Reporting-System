using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.CORE.Enums;

namespace BC.ACCOUNTING.CORE.DTO.Report;

public record ReportResponseDTO 
{
    public int Id { get; set; }
    public string MainReport { get; set; } = string.Empty;
    public List<TDReportMode>? ReportModes { get; set; }
}