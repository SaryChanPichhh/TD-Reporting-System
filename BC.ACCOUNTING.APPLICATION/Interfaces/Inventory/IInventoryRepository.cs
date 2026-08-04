using BC.ACCOUNTING.CORE.DTO.Stock;
using BC.ACCOUNTING.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.Inventory
{
    public interface IInventoryRepository
    {
        Task<List<StockModel>> GetInventoryByDateRangeAsync(InventoryReqDto dto);
    }
}
