using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.PredefinedReports;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Inventory;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Purchase_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.Inventory;

namespace BC.ACCOUNTING.REPORT.Services
{
    public class CustomWebDocumentViewerReportResolver : IWebDocumentViewerReportResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomWebDocumentViewerReportResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public XtraReport Resolve(string reportName)
        {
            if (reportName == "DailySaleReport")
            {
                return _serviceProvider.GetRequiredService<DailySaleReport>();
            }
            else if (reportName == "InventoryReport")
            {
                return _serviceProvider.GetRequiredService<InventoryReport>();
            }
            else if (reportName == "PurchaseOrderReport")
            {
                return _serviceProvider.GetRequiredService<PurchaseOrderReport>();
            }
            else if (reportName == "SaleInvoiceReport")
            {
                return _serviceProvider.GetRequiredService<SaleInvoiceReport>();
            }
            else if (reportName == "DailySale80Report")
            {
                return _serviceProvider.GetRequiredService<DailySale80Report>();
            }
            else if (reportName == "SaleReport")
            {
                return _serviceProvider.GetRequiredService<SaleReport>();
            }
            throw new ArgumentException($"Unknown report name: {reportName}");
        }


        //public XtraReport Resolve(string reportEntry)
        //{
        //    if (reportEntry.StartsWith("EmployeeReport"))
        //    {
        //        XtraReport rep = CreateReport(reportEntry);
        //        rep.DataSource = CreateObjectDataSource(reportEntry);
        //        return rep;
        //    }
        //    return new XtraReport();
        //}

        private object CreateObjectDataSource(string reportName)
        {
            if (reportName == "EmployeeReport")
            {
                ObjectDataSource dataSource = new ObjectDataSource();
                dataSource.Name = "EmployeeObjectDS";
                dataSource.DataSource = typeof(EmployeeList);
                dataSource.Constructor = ObjectConstructorInfo.Default;
                dataSource.DataMember = "Items";
                return dataSource;
            }
            else
            if (reportName.EndsWith("7"))
            {
                ObjectDataSource dataSource = new ObjectDataSource();
                dataSource.Name = "EmployeeObjectDS";
                dataSource.DataSource = typeof(EmployeeList);
                // Specify the parameter's default value.
                var parameter = new Parameter("noOfItems", typeof(int), 7);
                dataSource.Constructor = new ObjectConstructorInfo(parameter);
                dataSource.DataMember = "Items";
                return dataSource;
            }
            else
            if (reportName.EndsWith("Parameter"))
            {
                ObjectDataSource dataSource = new ObjectDataSource();
                dataSource.Name = "EmployeeObjectDS";
                dataSource.DataSource = typeof(EmployeeList);
                // Map data source parameter to report's parameter.
                var parameter = new Parameter()
                {
                    Name = "noOfItems",
                    Type = typeof(DevExpress.DataAccess.Expression),
                    Value = new DevExpress.DataAccess.Expression("?parameterNoOfItems", typeof(int))
                };
                dataSource.Constructor = new ObjectConstructorInfo(parameter);
                dataSource.DataMember = "Items";
                return dataSource;
            }
            else
            {
                ObjectDataSource dataSource = new ObjectDataSource();
                dataSource.Name = "EmployeeObjectDS";
                dataSource.DataSource = typeof(EmployeeList);
                var parameterNoOfItems = new Parameter("noOfItems", typeof(int), 12);
                dataSource.Parameters.Add(parameterNoOfItems);
                dataSource.Constructor = ObjectConstructorInfo.Default;
                dataSource.DataMember = "GetData";
                return dataSource;
            }
        }

        private XtraReport CreateReport(string reportEntry)
        {
            return new XtraReport();
        }
    }

}
