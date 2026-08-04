using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace BC.ACCOUNTING.REPORT.DTO
{
    public record StockReqDto : ReportDto
    {
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }

        /// <summary>
        /// use for view report by item, date
        /// </summary>
        [AllowNull] public string SortOrder { get; set; } = string.Empty;

    }
}
