using BC.ACCOUNTING.APPLICATION.Interfaces.AR;
using BC.ACCOUNTING.APPLICATION.Interfaces.General;
using BC.ACCOUNTING.APPLICATION.Interfaces.Inventory;
using BC.ACCOUNTING.APPLICATION.Interfaces.Item;
using BC.ACCOUNTING.APPLICATION.Interfaces.ReportList;
using BC.ACCOUNTING.APPLICATION.Interfaces.SaleListing;
using BC.ACCOUNTING.APPLICATION.Interfaces.Setting;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.General
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBranchRepository branches, IUserRepository users, IAccountRecievableService accountRecievables, ISaleListingRepository saleListingRepository, IItemRepository itemRepository, IInventoryRepository inventoryRepository, IReportService reportService, ISettingInvoicePresetRepository settingInvoicePresetRepository, IReportManagementRepository reportManagementRepository)
        {
            Branches = branches;
            Users = users;
            AccountRecievables = accountRecievables;
            SaleListingRepository = saleListingRepository;
            ItemRepository = itemRepository;
            InventoryRepository = inventoryRepository;
            ReportService = reportService;
            SettingInvoicePresetRepository = settingInvoicePresetRepository;
            ReportManagementRepository = reportManagementRepository;
        }
        public IBranchRepository Branches { get; set; }
        public IAccountRecievableService AccountRecievables { get; }
        public ISaleListingRepository SaleListingRepository { get; }
        public IItemRepository ItemRepository { get; }
        public IUserRepository Users { get; set; }
        public IInventoryRepository InventoryRepository { get; set; }
        public IReportService ReportService { get; set; }

        public ISettingInvoicePresetRepository SettingInvoicePresetRepository { set; get; }
        public IReportManagementRepository ReportManagementRepository { get; }
    }
}
