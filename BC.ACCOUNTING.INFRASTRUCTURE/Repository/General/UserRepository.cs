using BC.ACCOUNTING.APPLICATION.Interfaces.General;
using BC.ACCOUNTING.CORE.DTO.General;
using BC.ACCOUNTING.CORE.DTO.Login;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;
using Microsoft.Data.SqlClient;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.General
{
    public class UserRepository : IUserRepository
    {

        #region ===[ Private Members ]=============================================================
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly IInvoiceClosingEntryRepository _invoiceClosingEntryRepository;

        #endregion

        #region ===[ Constructor ]=================================================================

        public UserRepository(ISqlDataAccess sqlDataAccess, IInvoiceClosingEntryRepository invoiceClosingEntryRepository)
        {
            _sqlDataAccess = sqlDataAccess;
            _invoiceClosingEntryRepository = invoiceClosingEntryRepository;
        }

        #endregion

        #region ===[ IUserRepository Methods ]==================================================

       

        public async Task<User> GetBcUserCredential(LoginRequestDTO requestDto)
        {
            try
            {
                var sql =
                    @"SELECT 
                    U.USER_ID UserId, 
                    U.USER_NAME Username, 
                    M.DB_CODE DbCode, 
                    CONCAT(U.FIRST_NAME, ' ', U.LAST_NAME) AS [Name], 
                    U.USER_PASS UserPass,
                    GETDATE() CurrentDate
                FROM 
                    dbo.BCUSERS U
                INNER JOIN 
                    dbo.BCMSAPP M 
                    ON M.USER_ID = U.USER_ID
                WHERE 
                    U.USER_NAME = @USER_NAME
                    AND M.DB_CODE = @DB_CODE 
                    AND M.APP_CODE = @APP_CODE
                    AND U.USER_STATUS = 1;";
                var param = new
                {
                    USER_NAME = requestDto.Username,
                    APP_CODE = requestDto.AppCode,
                    DB_CODE = requestDto.DbCode,
                    COMPANYCODE = requestDto.CompanyCode,
                };
                var result = await _sqlDataAccess.LoadSingleData<User, dynamic>(sql, param);
                if (requestDto.AppCode == "PYS")
                {
                    var entrycode = await _invoiceClosingEntryRepository.CheckIsEntriesIsAlreadyOpenAsync(requestDto.DbCode);
                    if (!entrycode)
                    {
                        var generateOpeningEntryCodeAsync = await _invoiceClosingEntryRepository.GenerateOpeningEntryCodeAsync(requestDto.DbCode);
                        await _invoiceClosingEntryRepository.CreateClosingEntryAsync(new InvoiceClosingEntriesModel()
                        {
                            IsActive = true,
                            CreatedBy = "System",
                            CreatedDate = DateTime.Now,
                            Code = generateOpeningEntryCodeAsync,
                            Description = "Auto Generate Opening Entry By System",
                        }, requestDto.DbCode);
                    }
                    var openingEntryCodeByDbCodeAsync = await _invoiceClosingEntryRepository.GetOpeningEntryCodeByDbCodeAsync(requestDto.DbCode);
                    result.InvoiceEntryCode = openingEntryCodeByDbCodeAsync;
                }


                return result;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
        public async Task<User> GetUserByIdAsync(ContextDTO contextDto)
        {
            var sql = 
                @"SELECT 
                    U.USER_ID UserId, 
                    U.USER_NAME Username, 
                    M.DB_CODE DbCode, 
                    CONCAT(U.FIRST_NAME, ' ', U.LAST_NAME) AS [Name], 
                    U.USER_PASS UserPass,
                    GETDATE() CurrentDate
                FROM 
                    dbo.BCUSERS U
                INNER JOIN 
                    dbo.BCMSAPP M 
                    ON M.USER_ID = U.USER_ID
                WHERE 
                    U.USER_ID = @USER_ID
                    AND M.DB_CODE = @DB_CODE 
                    AND M.APP_CODE = @APP_CODE
                    AND U.USER_STATUS = 1";
            var param = new
            {
                USER_ID = contextDto.UserId,
                APP_CODE = contextDto.AppCode,
                DB_CODE = contextDto.DbCode,
            };
            return (await _sqlDataAccess.LoadSingleData<User, dynamic>(sql, param));

        }

        public async Task<string> GetUserForOTP(string username)
        {
            var sql =
                @"SELECT USER_ID FROM BCUSERS WHERE USER_NAME = @USER_NAME AND USER_STATUS = '1'";
            var param = new
            {
                USER_NAME = username
            };
            return (await _sqlDataAccess.LoadSingleData<string, dynamic>(sql, param));

        }




        #endregion
    }
}

