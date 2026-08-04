using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using BC.ACCOUNTING.REPORT.DataSources;

namespace BC.ACCOUNTING.REPORT.Helper
{
    public static class ReportHelper
    {
        #region Initialization Report+

        private static readonly
            Dictionary<string, Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>> Reports =
                new()

                {
                    {
                        "POSSaleInvoice80Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.DeliveryFeeMode, "POSSaleInvoice80EngReport.repx"),
                                    (ReportModes.NormalMode, "POSSaleInvoice80EngReport.repx"),
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.DeliveryFeeMode, "POSSaleInvoice80Report.repx"),
                                    (ReportModes.NormalMode, "POSSaleInvoice80Report.repx")
                                }
                            },
                        }
                    },
                    {
                        "DailyClosingInventoryDetail80mmReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryDetail80mmReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.DeliveryFeeMode, "DailyClosingInventoryDetail80mmReport.repx"),
                                    (ReportModes.NormalMode, "DailyClosingInventoryDetail80mmReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "DailyClosingInventoryDetailA4Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryDetailA4Report.repx"),
                                    (ReportModes.NormalMode, "DailyClosingInventoryDetailA4Report.repx"),
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.DeliveryFeeMode, "DailyClosingInventoryDetailA4Report.repx"),
                                    (ReportModes.NormalMode, "DailyClosingInventoryDetailA4Report.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSSaleInvoiceReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleInvoiceEVReport.repx"),
                                    (ReportModes.DeliveryFeeMode, "POSSaleInvoiceEVWithDeliveryReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.DeliveryFeeMode, "POSSaleInvoiceWithDeliveryFeeReport.repx"),
                                    (ReportModes.NormalMode, "POSSaleInvoiceReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSSaleInvoiceA5Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleInvoiceA5Report.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.DeliveryFeeMode, "POSSaleInvoiceA5Report.repx"),
                                    (ReportModes.NormalMode, "POSSaleInvoiceA5Report.repx")
                                }
                            },
                        }
                    },
                    {
                        "A4DailyClosingInventoryReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "A4DailyClosingInventoryEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "A4DailyClosingInventoryReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "DailyClosingInventoryReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "DailyClosingInventoryByCategory80Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryByCategory80Report.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryByCategory80Report.repx")
                                }
                            },
                        }
                    },
                    {
                        "DailyClosingInventoryByCategoryA4Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryByCategoryA4Report.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryByCategoryA4Report.repx")
                                }
                            },
                        }
                    },
                    {
                        "DailyClosingReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "CustomerOrderReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "CustomerOrderEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "CustomerOrderReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSSaleListingReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleListingEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleListingReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "SaleListingByInvoiceReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByInvoiceEVReport.repx"),
                                    (ReportModes.DeliveryFeeMode, "SaleListingByInvoiceWithDeliveryFeeEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByInvoiceReport.repx"),
                                    (ReportModes.DeliveryFeeMode, "SaleListingByInvoiceWithDeliveryFeeReport.repx"),
                                }
                            },
                        }
                    },
                    {
                        "SaleListingMovementReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingMovementEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingMovementReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "IUInventoryAuditA4Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "IUInventoryAuditA4EVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "IUInventoryAuditA4Report.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSInventoryOutOfStockReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSInventoryOutOfStockEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSInventoryOutOfStockReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSSaleListingSummaryReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleListingSummaryEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleListingSummaryReport.repx"),
                                    (ReportModes.DeliveryFeeMode, "SaleListingByInvoiceWithDeliveryFeeReport.repx"),
                                }
                            },
                        }
                    },
                    {
                        "SaleListingByDateReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByDateEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByDateReport.repx"),
                                    (ReportModes.DeliveryFeeMode, "SaleListingByDateWithDeliveryFeeReport.repx"),
                                }
                            },
                        }
                    },
                    {
                        "SaleListingBySellerReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingBySellerEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingBySellerReport.repx"),
                                    (ReportModes.DeliveryFeeMode, "SaleListingBySellerWithDeliveryFeeReport.repx"),
                                }
                            },
                        }
                    },
                    {
                        "SaleListingBySellerNoProfitReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingBySellerNoProfitEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingBySellerNoProfitReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "SaleListingByInvoiceNoProfitReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByInvoiceNoProfitEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByInvoiceNoProfitReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSPurchaseOrderByDateReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderByDateEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderByDateReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSPurchaseOrderByInvoiceReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderByInvoiceEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderByInvoiceReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSPurchaseOrderBySupplierReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderBySupplierEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderBySupplierReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSPurchaseOrderListingReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderListingEVReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderListingReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSPOListingReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPOListingReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPOListingReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "AKASaleInvoiceA5Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "AKASaleInvoiceA5Report.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "AKASaleInvoiceA5Report.repx")
                                }
                            },
                        }
                    },
                };

        #endregion

        #region Report Configuration For Generate Empty Rows

        public static Dictionary<string, (int small, int medium, int large, int subPage, int subPages)> ReportConfigs =
            new()
            {
                { "HL7SaleInvoiceA5PortraitReport", (12, 41, 18, 23, 27) },
                { "DefaultSaleInvoiceA5Report", (18, 43, 18, 23, 27) },
                { "KM7SaleInvoiceA5PortraitReport", (15, 43, 18, 23, 27) },
                { "KM7SaleInvoiceA5PortraitSecondaryReport", (15, 43, 18, 23, 27) },
                { "HK7SaleInvoiceA5PortraitReport", (14, 41, 18, 23, 27) },
                { "HL7SaleInvoiceA5Report", (9, 28, 27, 19, 27) },
                { "CH7SaleInvoiceA5PortraitReport", (13, 41, 18, 23, 27) },
            };
        #endregion

        public static string
            GetReportPath(string reportDirectory, string? folderPath, string reportName,
                Languages language = Languages.KM, ReportModes reportMode = ReportModes.NormalMode)
        {
            var reportVer = Reports.ContainsKey(reportName) && Reports[reportName].ContainsKey(language)
                                                            && Reports[reportName][language]
                                                                .Any(x => x.reportModes == reportMode)
                ? Reports[reportName][language].Where(x => x.reportModes.Equals(reportMode)).Select(x => x.reportName)
                    .FirstOrDefault() ?? string.Empty
                : string.Empty;
            return Path.Combine(reportDirectory, folderPath, reportVer);
        }

        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes &&
                attributes.Length != 0)
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
        public static string GrandTotalDisplayByCurrency(ExchangesCurrency currencySymbol)
        {
            return currencySymbol switch
            {
                ExchangesCurrency.KHR => "សរុបរៀល",
                ExchangesCurrency.USD => "សរុបដុល្លារ",
                ExchangesCurrency.BTH => "សរុបបាត",
                ExchangesCurrency.VND => "សរុបដុង",
                _ => "សរុបដុល្លារ",
            };

        }
        public static string FormatCurrency(decimal value, DecimalFormatting format)
        {
            var formatString = format.GetEnumDescription();
            var formattedValue = string.Format(formatString, value);
            return "$" + formattedValue;
        }
        public static string GetReportClosingInventoryNameByCode(List<string> branches,string dbCode, string reportName)
        {
            var reportReturnName = string.Empty;
            if  ( branches is not [] && branches.Contains(dbCode))
            {
                reportReturnName = reportName switch
                {
                    "DailyClosingInventoryReport" => "DailyClosingInventoryByCategory80Report",
                    "A4DailyClosingInventoryReport" => "DailyClosingInventoryByCategoryA4Report",
                    _ => reportReturnName
                };
            }
            else
            {
                reportReturnName = reportName;
            }
            return reportReturnName;
        }
        public static string AddressFormatting(AddressDataSource address, AddressFormatting addressEnum)
        {
            if (addressEnum.Equals(Enums.AddressFormatting.DESC))
            {
                return string.Join(", ", new[]
                {
                    address.Province,
                    address.District,
                    address.Commune,
                    address.HomeAddress,
                    address.Street
                }.Where(x => !string.IsNullOrWhiteSpace(x)));
            }
            else
            {
                return string.Join(", ", new[]
                {
                    address.Street,
                    address.HomeAddress,
                    address.Commune,
                    address.District,
                    address.Province
                }.Where(x => !string.IsNullOrWhiteSpace(x)));
            }

        }
        public static List<FlatInvoiceRow> GenerateEmptyData(List<FlatInvoiceRow> data, int P1_SMALL,
            int P1_MEDIUM_SIZE, int P1_LARGE, int SUB_PAGE_SIZE, int SUB_PAGES_SIZE)
        {
            var total = data.Count;
            var targetCount = 0;
            if (total <= P1_SMALL)
            {
                targetCount = P1_SMALL;
            }
            else if (total <= P1_MEDIUM_SIZE)
            {
                targetCount = P1_MEDIUM_SIZE;
            }
            else
            {
                if (total <= P1_LARGE)
                {
                    targetCount = P1_LARGE;
                }
                else if (total <= (P1_LARGE + SUB_PAGE_SIZE))
                {
                    var overflow = total - P1_LARGE;
                    var subPagesNeeded = (overflow + SUB_PAGE_SIZE - 1) / SUB_PAGE_SIZE;
                    targetCount = P1_LARGE + (subPagesNeeded * SUB_PAGE_SIZE);
                }
                else
                {
                    var overflow = total - (P1_LARGE + SUB_PAGE_SIZE);
                    var subPagesNeeded = (overflow + SUB_PAGES_SIZE - 1) / SUB_PAGES_SIZE;
                    targetCount = P1_LARGE + SUB_PAGE_SIZE + (subPagesNeeded * SUB_PAGES_SIZE);
                }
            }
            var padding = targetCount - total;
            if (padding > 0)
            {
                AddFillerRows(data, padding);
            }
            
            return data;
        }

        public static void AddFillerRows(List<FlatInvoiceRow> data, int count)
        {
            for (int i = 0; i < count; i++)
            {
                data.Add(new FlatInvoiceRow()
                {
                    RowNumber = string.Empty,
                    ItemDesc = string.Empty,
                    Qty = 0,
                    Price = null,
                    Total = null
                });
            }
        }

        public static (int small, int medium, int large, int subPage, int subPages) GetReportConfigByName(
            string reportName) =>
            ReportConfigs.TryGetValue(reportName, out var config) ? config 
                : new ();
    }
}
