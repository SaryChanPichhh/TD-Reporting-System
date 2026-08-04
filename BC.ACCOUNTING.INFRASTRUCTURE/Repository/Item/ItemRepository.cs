using BC.ACCOUNTING.API.Models;
using BC.ACCOUNTING.APPLICATION.Interfaces.Item;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.Item
{
    public class ItemRepository(ISqlDataAccess sqlDataAccess) : IItemRepository
    {
        public async Task<List<ItemModel>> GetItemsAsync(string dbCode, List<string> itemCodes)
        {
            var sql = $@"SELECT S.DB_CODE DbCode,S.ITEM_CODE ItemCode,S.ITEM_DESC ItemDesc,S.IMG Image 
            FROM SIITEMS S WHERE S.DB_CODE = @DB_CODE AND ITEM_CODE = @ITEM_CODE";
            var data = new List<ItemModel>();
            foreach (var param in itemCodes.Select(item => new
                     {
                         DB_CODE = dbCode,
                         ITEM_CODE = item,
                     }))
            {
              data.AddRange(await sqlDataAccess.LoadData<ItemModel, dynamic>(sql, param,connectionString:"MB"));
            }
            return data;
        }
    }
}
