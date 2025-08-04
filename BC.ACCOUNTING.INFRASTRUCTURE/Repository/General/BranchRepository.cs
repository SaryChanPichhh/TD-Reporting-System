using BC.ACCOUNTING.APPLICATION.Interfaces.General;
using BC.ACCOUNTING.CORE.DTO.General;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;
using static Dapper.SqlMapper;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.General
{
    public class BranchRepository :IBranchRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly ISqlDataAccess _sqlDataAccess;

        #endregion

        #region ===[ Constructor ]=================================================================

        public BranchRepository(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        #endregion

        #region ===[ Login Methods ]==================================================
        
        public async Task<List<BranchDTO>> GetLoginBranchAsync(string username, string appCode = "PYS")
        {
            var sql =
                @"SELECT 
                 si.DB_CODE AS DbCode,
                 si.DB_NAME AS DbName
                 FROM 
                 SIDB.dbo.TDSTINFO TD 
                 INNER JOIN SIDB.dbo.TDDBDET si ON si.COMPANYCODE = TD.COMPANY_CODE
                 INNER JOIN 
                 dbo.BCMSAPP ba ON si.DB_CODE = ba.DB_CODE
                 INNER JOIN 
                 dbo.BCUSERS bu ON ba.USER_ID = bu.USER_ID
                 WHERE 
                 TD.DB_STAT = 'A'
                 AND ba.APP_CODE = @APP_CODE
                 AND bu.USER_NAME = @USER_NAME;";
            return (await _sqlDataAccess.LoadData<BranchDTO, dynamic>(sql, new { USER_NAME = username, APP_CODE = appCode })).ToList();

        }

        public async Task<List<BranchDTO>> GetBranchAsync()
        {
            var sql = "SELECT DB_CODE DbCode,DB_NAME DbName FROM SIDBINFO WHERE DB_STAT = 'A'";
            return (await _sqlDataAccess.LoadData<BranchDTO, dynamic>(sql, new { })).ToList();
        }
        #endregion

        #region ===[ CRUD Branch methods  ]================================================== 

        public async Task<List<Branch>> GetAllAsync()
        {
            var sql =
                @"SELECT DB_CODE DbCode,
                       DB_NAME DbName,
                       DATE_DEFAULT DateDefault,
                       [DATE_FORMAT] [DateFormat],
                       SA_DECIMAL SaDecimal,
                       SB_DECICMA SbDecimal,
                       DEC_SEP DecSep,
                       THO_SEP ThoSep,
                       DB_STAT DbStat,
                       USER_CREA CreatedBy,
                       DATE_CREA CreatedDate,
                       USER_UPDT UpdatedBY,
                       DATE_UPDT UpdatedDate	 
                FROM dbo.SIDBINFO";
            return (await _sqlDataAccess.LoadData<Branch, dynamic>(sql, new { })).ToList();
        }

        public Task<Branch> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(Branch entity)
        {
            var sql =
                @" INSERT INTO dbo.SIDBINFO (DB_CODE, DB_NAME, DATE_DEFAULT, DATE_FORMAT, SA_DECIMAL, SB_DECICMA, DEC_SEP, THO_SEP, DB_STAT, USER_CREA, DATE_CREA, USER_UPDT, DATE_UPDT)
                                  VALUES (@DB_CODE, @DB_NAME, @DATE_DEFAULT, @DATE_FORMAT, @SA_DECIMAL, @SB_DECICMA, @DEC_SEP, @THO_SEP, @DB_STAT, @USER_CREA, @DATE_CREA, @USER_UPDT, @DATE_UPDT);";
            var param = new
            {
                DB_CODE = entity.DbCode,
                DB_NAME = entity.DbName,
                DATE_DEFAULT = entity.DateDefault,
                DATE_FORMAT = entity.DateFormat,
                SA_DECIMAL = entity.SaDecimal,
                SB_DECICMA = entity.SbDecimal,
                DEC_SEP = entity.DecSep,
                THO_SEP = entity.ThoSep,
                DB_STAT = entity.DbStat,
                USER_CREA = entity.CreatedBy,
                DATE_CREA = entity.CreatedDate,
                USER_UPDT = entity.UpdatedBy,
                DATE_UPDT = entity.UpdatedDate,
            };

            return await _sqlDataAccess.ExecuteAsync(sql, param);
        }

        public async Task<int> UpdateAsync(Branch entity)
        {
            var sql =
                @" UPDATE dbo.SIDBINFO
                    SET DB_NAME = @DB_NAME,
                        DATE_DEFAULT = @DATE_DEFAULT,
                        DATE_FORMAT = @DATE_FORMAT,
                        SA_DECIMAL = @SA_DECIMAL,
                        SB_DECICMA = @SB_DECICMA,
                        DEC_SEP = @DEC_SEP,
                        THO_SEP = @THO_SEP,
                        DB_STAT = @DB_STAT,
                        USER_UPDT = @USER_UPDT,
                        DATE_UPDT = @DATE_UPDT
                    WHERE DB_CODE = @DB_CODE;";
            var param = new
            {
                DB_CODE = entity.DbCode,
                DB_NAME = entity.DbName,
                DATE_DEFAULT = entity.DateDefault,
                DATE_FORMAT = entity.DateFormat,
                SA_DECIMAL = entity.SaDecimal,
                SB_DECICMA = entity.SbDecimal,
                DEC_SEP = entity.DecSep,
                THO_SEP = entity.ThoSep,
                DB_STAT = entity.DbStat,
                USER_UPDT = entity.UpdatedBy,
                DATE_UPDT = entity.UpdatedDate,
            };

            return await _sqlDataAccess.ExecuteAsync(sql, param);
        }

        public async Task<int> DeleteAsync(DeleteDTO dto)
        {
            var sql =
                @" UPDATE dbo.SIDBINFO
                    SET DB_STAT = @DB_STAT,
                        USER_UPDT = @USER_UPDT,
                        DATE_UPDT = @DATE_UPDT
                    WHERE DB_CODE = @DB_CODE;";
            var param = new
            {
                DB_CODE = dto.Code,
                DB_STAT = dto.Status == "A" ? "D" : "A",
                USER_UPDT = dto.UpdatedBy,
                DATE_UPDT = dto.UpdatedDate,
            };

            return await _sqlDataAccess.ExecuteAsync(sql, param);
        }

        #endregion
    }
}
