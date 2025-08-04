using System;
using System.Collections.Generic;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DTO;
using DevExpress.DataAccess.Web;

namespace BC.ACCOUNTING.REPORT.Services
{
    public class ObjectDataSourceWizardCustomTypeProvider : IObjectDataSourceWizardTypeProvider
    {
        public IEnumerable<Type> GetAvailableTypes(string context)
        {
            return new[] { typeof(Aging),typeof(InvoiceReportDto) };
        }
    }
}
