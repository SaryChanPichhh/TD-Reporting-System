using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.ReportList
{
    public interface IReportPermissionService
    {
        public Task<List<TDReport>> GetAllReportAsync(string connection = "DBConnection");
        public Task<int> CreateReportAsync(TDReport report);
        public Task<int> UpdateReportAsync(TDReport report);
        public Task<int> DeleteReportAsync(TDReport report);
    }
}
