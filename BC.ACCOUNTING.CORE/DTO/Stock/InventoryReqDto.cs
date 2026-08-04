using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.ACCOUNTING.CORE.DTO.General;

namespace BC.ACCOUNTING.CORE.DTO.Stock
{
    public class InventoryReqDto 
    {
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        public string Connection { get; set; } = "default";
        public string DbCode { get; set; } = string.Empty;
    }
}
