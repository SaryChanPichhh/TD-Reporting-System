using BC.ACCOUNTING.CORE.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.General
{
    public interface IBranchRepository:IRepository<Branch>
    {
        public Task<List<BranchDTO>> GetLoginBranchAsync(string username, string appCode = "PYS");
        public Task<List<BranchDTO>> GetBranchAsync();
        public Task<string> GetCompanyCodeByBranchCodeAsync(string dbCode);

    }
}
