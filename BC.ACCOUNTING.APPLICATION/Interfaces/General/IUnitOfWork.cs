using BC.ACCOUNTING.APPLICATION.Interfaces.AR;
using BC.ACCOUNTING.APPLICATION.Interfaces.SaleListing;
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
    }
}
