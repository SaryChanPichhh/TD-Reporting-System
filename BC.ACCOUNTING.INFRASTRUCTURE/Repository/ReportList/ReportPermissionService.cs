using BC.ACCOUNTING.APPLICATION.Interfaces.ReportList;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;
using Microsoft.Extensions.Configuration;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.ReportList
{
    public class ReportPermissionService :IReportPermissionService
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly IConfiguration _configuration;

        public ReportPermissionService(ISqlDataAccess sqlDataAccess,IConfiguration configuration)
        {
            _sqlDataAccess = sqlDataAccess;
            _configuration = configuration;
        }
        public async Task<List<TDReport>> GetAllReportAsync(string connection = "DBConnection")
        {
            string connectionString = _configuration.GetConnectionString(connection);
            var sql =
                @"SELECT DB_CODE DbCode, REPORT_CODE ReportType, REPORT_NAME ReportName, [PATH] [Path], [STATUS] [Status] FROM TDREPORT";
            var result = await _sqlDataAccess.LoadData<TDReport, dynamic>(sql,new {},connectionString: connectionString);
            return result.ToList();
        }

        public Task<int> CreateReportAsync(TDReport report)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateReportAsync(TDReport report)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteReportAsync(TDReport report)
        {
            throw new NotImplementedException();
        }
    }
}
