using BC.ACCOUNTING.CORE.Enums;

namespace BC.ACCOUNTING.CORE.Entities;

public class TDReportMode
{
    public int Id { get; set; }
    public string HeaderName { get; set; } = string.Empty;
    public ReportModes ReportMode { get; set; } 
    public string ReportName { get; set; } = string.Empty;
    public Languages ReportLanguage { get; set; } 
}