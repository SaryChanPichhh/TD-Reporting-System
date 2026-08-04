using BC.ACCOUNTING.APPLICATION.Interfaces.AR;
using BC.ACCOUNTING.APPLICATION.Interfaces.General;
using BC.ACCOUNTING.APPLICATION.Interfaces.Inventory;
using BC.ACCOUNTING.APPLICATION.Interfaces.Item;
using BC.ACCOUNTING.APPLICATION.Interfaces.ReportList;
using BC.ACCOUNTING.APPLICATION.Interfaces.SaleListing;
using BC.ACCOUNTING.APPLICATION.Interfaces.Setting;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;
using BC.ACCOUNTING.INFRASTRUCTURE.Repository;
using BC.ACCOUNTING.INFRASTRUCTURE.Repository.AR;
using BC.ACCOUNTING.INFRASTRUCTURE.Repository.General;
using BC.ACCOUNTING.INFRASTRUCTURE.Repository.Inventory;
using BC.ACCOUNTING.INFRASTRUCTURE.Repository.Item;
using BC.ACCOUNTING.INFRASTRUCTURE.Repository.ReportList;
using BC.ACCOUNTING.INFRASTRUCTURE.Repository.SaleListing;
using BC.ACCOUNTING.INFRASTRUCTURE.Repository.Setting;
using Microsoft.Extensions.DependencyInjection;

namespace BC.ACCOUNTING.INFRASTRUCTURE
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IReportPermissionService, ReportPermissionService>();
            services.AddTransient<IInvoiceClosingEntryRepository, InvoiceClosingEntryRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAccountRecievableService, AccountRecievableService>();
            services.AddTransient<ISaleListingRepository, SaleListingRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<ISettingInvoicePresetRepository, SettingInvoicePresetService>();
        }
    }
}
