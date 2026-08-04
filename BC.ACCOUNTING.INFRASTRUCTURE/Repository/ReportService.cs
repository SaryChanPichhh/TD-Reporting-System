using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.ACCOUNTING.APPLICATION.Interfaces.ReportList;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository
{
    public class ReportService(ISqlDataAccess sqlDataAccess,IConfiguration setting) : IReportService
    {
        
        public async Task<bool> CloneReportAsync(string fromBranch,string toBranch)
        {
            var sql = $@"SELECT T1.DB_CODE DbCode
                      ,T1.REPORT_NAME ReportName
                      ,T1.PATH Path
                      ,T1.STATUS Status
                      ,T1.REPORT_TYPE ReportType
                      ,T1.ID Id
                      ,T.RID Rid
                      ,T.REPORT_NAME ReportDesc
                      ,T.PATH_SUFFIX PathSuffix
                      ,T.FILTER_KEY FilterKey
                      ,T.PAPER_SIZE PaperSize
                      ,T.FIELD Field FROM TDREPORT T1 
                INNER JOIN TDREPORTDET T
                ON T1.ID = T.RID
                 WHERE T1.DB_CODE = @FROM_BRANCH;
                 ";
            var getReports = await sqlDataAccess.LoadData<ReportModel, dynamic>(sql, new { FROM_BRANCH = fromBranch });
            var affectedRow = 0;
            foreach (var report in getReports)
            {
                var sqlInsert = $@"INSERT_NEW_REPORT";
                var param = new
                {
                    DB_CODE = toBranch,
                    REPORT_TITLE_NAME = report.ReportName,
                    PATH = report.Path,
                    REPORT_TYPE = report.ReportType,
                    REPORT_NAME = report.ReportDesc, 
                    PATH_SUFFIX = report.PathSuffix,
                    FILTER_KEY = report.FilterKey,
                    PAPER_SIZE = report.PaperSize,
                    FIELD = report.Field
                };
                affectedRow += await sqlDataAccess.ExecuteAsync(sqlInsert, param,CommandType.StoredProcedure);
            }
            return affectedRow == getReports.Count()*2;
        }

        public async Task<bool> DeleteReportAsync(string branch)
        {
            var connection = new SqlConnection(setting.GetConnectionString("DBConnection")!);
            var transaction = connection.BeginTransaction();
            connection.Open();

            try
            {
                var deleteDetail = $@"DELETE FROM TDREPORTDET WHERE RID IN (SELECT ID FROM TDREPORT WHERE DB_CODE = @DB_CODE)";
                var execute = await connection.ExecuteAsync(deleteDetail, new { DB_CODE = branch },transaction);
                var deleteHeader = $@"";

            }
            finally
            {
                connection.Close();
            }
            
            throw new NotImplementedException();
        }
    }
}
