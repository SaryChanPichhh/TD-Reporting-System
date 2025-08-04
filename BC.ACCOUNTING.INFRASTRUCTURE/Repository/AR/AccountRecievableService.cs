using BC.ACCOUNTING.APPLICATION.Interfaces.AR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.ACCOUNTING.CORE.DTO.AR;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;
using BC.ACCOUNTING.INFRASTRUCTURE.Helper;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.AR
{
    public class AccountRecievableService: IAccountRecievableService
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public AccountRecievableService(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public async Task<List<Aging>> GetAgingReport(AgingDto dto)
        {
            AppExtension.RegisterColumnMapping<Aging>();
            string pro = @$"dbo.{dto.DB_CODE}SI_SELECT_AGING";
            var param = new
            {
                DB_CODE = dto.DB_CODE,
                BY_DATE = dto.BY_DATE,
                FROM_ACC = dto.FROM_ACC,
                TO_ACC = dto.TO_ACC,
                ACC_TYPE = dto.ACC_TYPE,
                T = dto.T,
                FROM_ANAL = dto.FROM_ANAL,
                TO_ANAL = dto.TO_ANAL,
                T0 = dto.T0,
                T1 = dto.T1,
                T2 = dto.T2,
                T3 = dto.T3,
                T4 = dto.T4,
                T5 = dto.T5,
                T6 = dto.T6,
                T7 = dto.T7,
                T8 = dto.T8,
                T9 = dto.T9
            };

            var result =  await _sqlDataAccess.LoadData<Aging, dynamic>(pro, param, CommandType.StoredProcedure,dto.Connection);
           
            return result.ToList();
        }
    }
}
