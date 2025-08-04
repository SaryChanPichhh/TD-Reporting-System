using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.CORE.DTO.General
{
    public record BranchDTO
    {
        public string DbCode { get; set; }
        public string DbName { get; set; }
    }
}
