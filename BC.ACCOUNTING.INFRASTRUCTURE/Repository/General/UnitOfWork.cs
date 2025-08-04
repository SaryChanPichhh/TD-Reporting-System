using BC.ACCOUNTING.APPLICATION.Interfaces.AR;
using BC.ACCOUNTING.APPLICATION.Interfaces.General;
using BC.ACCOUNTING.APPLICATION.Interfaces.SaleListing;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.General
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IBranchRepository branches, IUserRepository users, IAccountRecievableService accountRecievables, ISaleListingRepository saleListingRepository)
        {
            Branches = branches;
            Users = users;
            AccountRecievables = accountRecievables;
            SaleListingRepository = saleListingRepository;
        }

        public IBranchRepository Branches { get; set; }
        public IAccountRecievableService AccountRecievables { get; }
        public ISaleListingRepository SaleListingRepository { get; }
        public IUserRepository Users { get; set; }
        
        
    }
}
