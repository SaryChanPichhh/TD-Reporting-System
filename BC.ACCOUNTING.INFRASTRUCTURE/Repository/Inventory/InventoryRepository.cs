using BC.ACCOUNTING.APPLICATION.Interfaces.Inventory;
using BC.ACCOUNTING.CORE.DTO.Stock;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.Inventory
{
    public class InventoryRepository(ISqlDataAccess sqlDataAccess) : IInventoryRepository
    {
        public async Task<List<StockModel>> GetInventoryByDateRangeAsync(InventoryReqDto dto)
        {
            var sql = $@"SELECT [PIVOT].Location
                      ,[PIVOT].ItemCode
                      ,[PIVOT].ItemDesc
                      ,[PIVOT].MovDate
                      ,[PIVOT].OpeningInventory
                      ,[PIVOT].PurchaseOrder
                      ,[PIVOT].Sale
                      ,[PIVOT].Transfer
                      ,[PIVOT].CreditNote
                      ,[PIVOT].InventoryAdjustment FROM(
                      SELECT [LOCATION] [Location],MOV.ITEM_CODE ItemCode,S.ITEM_DESC ItemDesc,QUANTITY Quantity,TRY_CONVERT(DATETIME,MOV_DATE,101) [MovDate],
                      CASE WHEN REC_TYPE = 'T' THEN 'Transfer'
                      WHEN REC_TYPE = 'P' THEN 'PurchaseOrder'
                      WHEN REC_TYPE = 'S' THEN 'Sale' 
                      WHEN REC_TYPE = 'C' THEN 'CreditNote' 
                      WHEN REC_TYPE = 'M' THEN 'InventoryAdjustment'  
                      WHEN REC_TYPE = 'O' THEN 'OpeningInventory'
                      END [Status]
                      FROM {dto.DbCode}SIINVMOV MOV INNER JOIN SIITEMS S ON MOV.ITEM_CODE = S.ITEM_CODE
                        WHERE REC_TYPE IN ('T','P','S','C','M','O') AND TRY_CONVERT(DATETIME,MOV_DATE,101) BETWEEN CONVERT(DATETIME,@START_DATE,101)
                    AND CONVERT(DATETIME,@END_DATE,101)
                   ) TAB PIVOT (SUM(Quantity) FOR [Status] IN ([OpeningInventory], [PurchaseOrder],[Sale],[Transfer],[CreditNote],[InventoryAdjustment])) AS [PIVOT]
                ";
            var execute = await sqlDataAccess.LoadData<StockModel,dynamic>(sql,new
            {
                START_DATE = dto.FromDate,END_DATE = dto.ToDate,
            },connectionString:dto.Connection);
            return execute.ToList();
        }
    }
}
