using System.ComponentModel;
using BC.ACCOUNTING.REPORT.Models;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record ReportDto
    {
        [Browsable(false)]
        public required string ReportName { get; set; }

        [Browsable(false)]
        public Export? ExportFormat { get; set; } = null; // null = View, otherwise Export

        [Browsable(false)] public string? Connection { get; set; } = "Default";

    }
}
