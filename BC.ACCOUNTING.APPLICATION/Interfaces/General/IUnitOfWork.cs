using BC.ACCOUNTING.APPLICATION.Interfaces.AR;
using BC.ACCOUNTING.APPLICATION.Interfaces.Inventory;
using BC.ACCOUNTING.APPLICATION.Interfaces.Item;
using BC.ACCOUNTING.APPLICATION.Interfaces.ReportList;
using BC.ACCOUNTING.APPLICATION.Interfaces.SaleListing;
using BC.ACCOUNTING.APPLICATION.Interfaces.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.General
{
    public interface IUnitOfWork
    {
        
        IUserRepository Users { get; }
        IBranchRepository Branches { get; }
        IAccountRecievableService AccountRecievables{ get; }
        ISaleListingRepository SaleListingRepository { get; }
        IItemRepository ItemRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IReportService ReportService { get; }
        ISettingInvoicePresetRepository SettingInvoicePresetRepository { get; }
    }
}
