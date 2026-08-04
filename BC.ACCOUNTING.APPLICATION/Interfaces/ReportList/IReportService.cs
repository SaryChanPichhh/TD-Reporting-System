using BC.ACCOUNTING.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.ReportList
{
    public interface IReportService
    {
        Task<bool> CloneReportAsync(string fromBranch,string toBranch);
        Task<bool> DeleteReportAsync(string branch);
    }
}
