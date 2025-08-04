using BC.ACCOUNTING.CORE.DTO.AR;
using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.AR
{
    public interface IAccountRecievableService
    {
        public Task<List<Aging>> GetAgingReport(AgingDto dto);
    }
}
