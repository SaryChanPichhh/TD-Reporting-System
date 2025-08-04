using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.REPORT.DataSources;
using DevExpress.DataAccess.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BC.ACCOUNTING.REPORT.Services;

public class CustomObjectDataSourceConstructorFilterService : IObjectDataSourceConstructorFilterService
{
    public IEnumerable<ConstructorInfo> Filter(Type dataSourceType, IEnumerable<ConstructorInfo> constructors)
    {
        if (dataSourceType == typeof(Aging))
            return constructors;
        else
            return constructors.Where(x => x.GetParameters().Length > 0);
    }
}