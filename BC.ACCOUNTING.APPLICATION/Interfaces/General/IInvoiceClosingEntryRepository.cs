using BC.ACCOUNTING.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.General
{
    public interface IInvoiceClosingEntryRepository
    {
        Task<bool> CheckIsEntriesIsAlreadyOpenAsync(string dbCode);
        Task<int> CreateClosingEntryAsync(InvoiceClosingEntriesModel closingEntry, string dbCode);
        Task<string> GenerateOpeningEntryCodeAsync(string dbCode);
        Task<string> GetOpeningEntryCodeByDbCodeAsync(string dbCode);
    }
}
