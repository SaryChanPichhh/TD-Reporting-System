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
            Dictionary<string, Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>> reports =
                new()

                {
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
                                    (ReportModes.NormalMode, "DailyClosingInventoryDetailA4Report.repx")
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
                                    (ReportModes.NormalMode, "POSSaleInvoiceEVReport.repx")
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
                    },{
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
                            },{
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
                            },{
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryReport.repx")
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
                            },{
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
                            },{
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
                            },{
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
                                    (ReportModes.NormalMode, "SaleListingByInvoiceEVReport.repx")
                                }
                            },{
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
                            },{
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
                            },{
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
                            },{
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
                            },{
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleListingSummaryReport.repx"),
                                    (ReportModes.DeliveryFeeMode , "SaleListingByInvoiceWithDeliveryFeeReport.repx"),
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
                            },{
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
                            },{
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingBySellerReport.repx"),
                                    (ReportModes.DeliveryFeeMode , "SaleListingBySellerWithDeliveryFeeReport.repx"),
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
                            },{
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
                            },{
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
                            },{
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
                            },{
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
                            },{
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
                            },{
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
                            },{
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPOListingReport.repx")
                                }
                            },
                        }
                    },{
                        "AKASaleInvoiceA5Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "AKASaleInvoiceA5Report.repx")
                                }
                            },{
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

        #region Initialization Auto Print Report

        public static string ReportDirectory = "D:\\.NetAPI\\Reports\\Accounting";
        public static Dictionary<string, string> ImageUrl = new();

        private static readonly Dictionary<string, (Func<ReportDto> dtoFactory, Func<ReportDto, XtraReport> reportFactory)>
            AutoPrintReports = new()
            {
                {
                    "Y8SSaleInvoice80Report",
                    (
                        () => new SaleInvoiceDto(),                // Create DTO
                        dto => new SaleInvoiceReport(              // Create report with DTO
                            (SaleInvoiceDto)dto,
                            Path.Combine(ReportDirectory, "Y8SSaleInvoice80Report.repx"),
                            ImageUrl[ImagesPath.MB_SELLER_ROUTE.GetEnumDescription()]
                        )
                    )
                },
                {
                    "SA7SaleInvoice80Report",
                    (
                        () => new SaleInvoiceDto(),
                        dto => new SaleInvoiceReport(
                            (SaleInvoiceDto)dto,
                            Path.Combine(ReportDirectory, "SA7SaleInvoice80Report.repx"),
                            ImageUrl[ImagesPath.MB_SELLER_ROUTE.GetEnumDescription()]
                        )
                    )
                }
            };

        public static bool IsAutoPrint = false;
        public static string PrinterName = string.Empty;
        public static string ReportName = string.Empty;
        #endregion
        public static string 
            GetReportPath(string reportDirectory,string? folderPath, string reportName,Languages language = Languages.KM,ReportModes reportMode = ReportModes.NormalMode)
        {
            var reportVer = reports.ContainsKey(reportName) && reports[reportName].ContainsKey(language)
                                                                && reports[reportName][language].Any(x => x.reportModes == reportMode)
                ? reports[reportName][language].Where(x => x.reportModes.Equals(reportMode)).Select(x => x.reportName).FirstOrDefault()??string.Empty
                : string.Empty;
            return Path.Combine(reportDirectory, folderPath, reportVer);
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

        public static (ReportDto dto, Func<ReportDto, XtraReport> reportFactory)
            GetAutoPrintReportInstance(string reportName)
        {
            if (AutoPrintReports.TryGetValue(reportName, out var tuple))
                return (tuple.dtoFactory(), tuple.reportFactory);

            return (null, null);
        }
        public static string DisplayCurrency(ExchangesCurrency currencySymbol)
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

        public static string AddressFormatting(AddressDataSource address,AddressFormatting addressEnum)
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
    }
}
