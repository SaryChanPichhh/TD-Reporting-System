using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.CORE.DTO.General
{
    public record DeleteDTO
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; } = DateTime.Today.ToString("MM/dd/yyyy");
    }
}
