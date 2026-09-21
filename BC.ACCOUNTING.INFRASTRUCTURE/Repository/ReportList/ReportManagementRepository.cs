using System.Data;
using BC.ACCOUNTING.APPLICATION.Interfaces.ReportList;
using BC.ACCOUNTING.CORE.DTO.Report;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;
using Dapper;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.ReportList;

public class ReportManagementRepository(IDbConnection _dbConnection) : IReportManagementRepository
{
    const string APP_CODE = "MB_POS";
    public async Task<List<ReportResponseDTO>> GetListReportAsync()
    {
        const string sqlQuery = $@"SELECT T.ID Id,T1.REPORT_NAME MainReport,TM.HEADER_NAME HeaderName,
                TM.REPORT_MODE ReportMode,TM.REPORT_NAME ReportName,TM.REPORT_LANGUAGE ReportLanguage
                 FROM TDREPORT T
                INNER JOIN TDREPORTDET T1
                ON T.ID = T1.RID 
                INNER JOIN TDREPORT_MODE TM ON T1.REPORT_NAME = TM.HEADER_NAME
                where T.APP_CODE = @APP_CODE AND T.STATUS = @STATUS
                ";
        var param = new
        {
            APP_CODE = APP_CODE,
            STATUS = true
        };

        var lookup = new Dictionary<string, ReportResponseDTO>();
        var execute = await _dbConnection.QueryAsync<ReportResponseDTO,TDReportMode,ReportResponseDTO>
            (sqlQuery,(report, reportMode) =>
            {
                if (!lookup.TryGetValue(report.MainReport, out var existing))
                {
                    existing = report;
                    existing.ReportModes = [];
                    lookup.Add(existing.MainReport, existing);
                }
                existing.ReportModes.Add(reportMode);
                return existing; 
            }, param,splitOn:"HeaderName");
        return lookup.Values.ToList();
    }
}