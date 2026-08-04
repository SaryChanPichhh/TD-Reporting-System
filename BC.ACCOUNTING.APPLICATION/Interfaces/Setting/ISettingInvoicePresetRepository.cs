using BC.ACCOUNTING.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.Setting
{
    public interface ISettingInvoicePresetRepository
    {
        Task<SettingInvoicePresetModel> GetSettingInvoicePresentAsync(string dbCode,string connection);
    }
}
