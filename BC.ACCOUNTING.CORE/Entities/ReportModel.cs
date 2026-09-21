using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.CORE.Entities
{
    public class ReportModel
    {
        public int Id { get; set; }
        public string DbCode { get; set; } = string.Empty;
        public string ReportName { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string ReportType { get; set; } = string.Empty;
        public int Rid { get; set; }
        public string ReportDesc { get; set; } = string.Empty;
        public string PathSuffix { get; set; } = string.Empty;
        public string FilterKey { get; set; } = string.Empty;
        public string PaperSize { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public string AppCode { get; set; } = string.Empty;
    }
}
