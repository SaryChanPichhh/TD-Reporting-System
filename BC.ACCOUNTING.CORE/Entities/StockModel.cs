using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.CORE.Entities
{
    public class StockModel
    {
        public DateTime MovDate { get; set; }
        public string ItemCode { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; } = 0;
        public int OpeningInventory { get; set; } = 0;
        public int InventoryAdjustment { get; set; } = 0;
        public int CreditNote { get; set; } = 0;
        public int Sale { get; set; } = 0;
        public int PurchaseOrder { get; set; } = 0;
        public int Transfer { get; set; } = 0;
    }
}
