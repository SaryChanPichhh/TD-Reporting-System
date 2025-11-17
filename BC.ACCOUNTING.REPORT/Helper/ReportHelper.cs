using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace BC.ACCOUNTING.REPORT.Helper
{
    public static class ReportHelper
    {
        #region Initialization Report

        private static readonly Dictionary<string, Dictionary<Languages, string>> reports = new()
        {
            {
                "A4DailyClosingInventoryReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "A4DailyClosingInventoryEVReport.repx" },
                }
            },
            {
                "DailyClosingInventoryReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "DailyClosingInventoryEVReport.repx" },
                }
            },
            {
                "DailyClosingReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "DailyClosingEVReport.repx" },
                }
            },
            {
                "CustomerOrderReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "CustomerOrderEVReport.repx" },
                }
            },
            {
                "POSSaleInvoiceReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "POSSaleInvoiceEVReport.repx" },
                }
            },
            {
                "POSSaleListingReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "POSSaleListingEVReport.repx" },
                }
            },
            {
                "SaleListingByInvoiceReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "SaleListingByInvoiceEVReport.repx" },
                }
            },
            {
                "SaleListingMovementReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "SaleListingMovementEVReport.repx" },
                }
            },
            {
                "IUInventoryAuditA4Report", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "IUInventoryAuditA4EVReport.repx" },
                }
            },{
                "POSInventoryOutOfStockReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "POSInventoryOutOfStockEVReport.repx" },
                }
            },{
                "POSSaleListingSummaryReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "POSSaleListingSummaryEVReport.repx" },
                }
            },{
                "SaleListingByDateReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "SaleListingByDateEVReport.repx" },
                }
            },{
                "SaleListingBySellerReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "SaleListingBySellerEVReport.repx" },
                }
            },{
                "SaleListingBySellerNoProfitReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "SaleListingBySellerNoProfitEVReport.repx" },
                }
            },{
                "SaleListingByInvoiceNoProfitReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "SaleListingByInvoiceNoProfitEVReport.repx" },
                }
            },{
                "POSPurchaseOrderByDateReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "POSPurchaseOrderByDateEVReport.repx" },
                }
            },{
                "POSPurchaseOrderByInvoiceReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "POSPurchaseOrderByInvoiceEVReport.repx" },
                }
            },{
                "POSPurchaseOrderBySupplierReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "POSPurchaseOrderBySupplierEVReport.repx" },
                }
            },{
                "POSPurchaseOrderListingReport", new Dictionary<Languages, string>
                {
                    { Languages.ENG, "POSPurchaseOrderListingEVReport.repx" },
                }
            },
        };
        #endregion
        public static string 
            GetReportPath(string reportDirectory,string folderPath, string reportName,Languages languages)
        {
            var reportVer = GetReportVerName(reportName,languages);
            return Path.Combine(reportDirectory, folderPath, reportVer);
        }

        public static string GetReportVerName(string reportName,Languages language)
        {
            return reports.ContainsKey(reportName) && reports[reportName].ContainsKey(language)
                ? reports[reportName][language]
                : string.Empty;
        }
        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static bool FromIntegerToBoolean(this int status)
        {
            return status switch
            {
                1 => true,
                _ => false,
            };
        }
    }
}
