using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.CORE.DTO.Login
{
    public record LoginResponseDTO
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string DbCode { get; set; }
    }
}
