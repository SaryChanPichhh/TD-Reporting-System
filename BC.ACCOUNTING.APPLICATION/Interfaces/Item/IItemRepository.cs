using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.ACCOUNTING.API.Models;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.Item
{
    public interface IItemRepository
    {
        Task<List<ItemModel>> GetItemsAsync(string dbCode,List<string> itemCodes);
    }
}
