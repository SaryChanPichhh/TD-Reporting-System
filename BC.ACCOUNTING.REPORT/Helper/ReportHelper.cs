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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.DeliveryFeeMode, "POSSaleInvoiceWithDeliveryFeeCNReport.repx"),
                                    (ReportModes.NormalMode, "POSSaleInvoiceCNReport.repx")
                                }
                            }
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.DeliveryFeeMode, "POSSaleInvoiceA5CNReport.repx"),
                                    (ReportModes.NormalMode, "POSSaleInvoiceA5CNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "A4DailyClosingInventoryCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingInventoryCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "DailyClosingCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "CustomerOrderCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleListingCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByInvoiceCNReport.repx"),
                                    (ReportModes.DeliveryFeeMode, "SaleListingByInvoiceWithDeliveryFeeCNReport.repx"),
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingMovementCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "IUInventoryAuditA4CNReport.repx")
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
                            {
                            Languages.ZH_CN,
                            new List<(ReportModes reportModes, string reportName)>
                            {
                                (ReportModes.NormalMode, "POSInventoryOutOfStockCNReport.repx")
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
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSSaleListingSummaryCNReport.repx")
                                }
                            },
                            {
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
                            },
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByDateCNReport.repx")
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
                            },{
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingBySellerReport.repx"),
                                    (ReportModes.DeliveryFeeMode , "SaleListingBySellerWithDeliveryFeeReport.repx"),
                                }
                            },
                            {
                            Languages.ZH_CN,
                            new List<(ReportModes reportModes, string reportName)>
                            {
                                (ReportModes.NormalMode, "SaleListingBySellerCNReport.repx"),
                                (ReportModes.DeliveryFeeMode , "SaleListingBySellerWithDeliveryFeeCNReport.repx"),
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingBySellerNoProfitCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "SaleListingByInvoiceNoProfitCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderByDateCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderByInvoiceCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderBySupplierCNReport.repx")
                                }
                            },
                        }
                    },
                    {
                        "POSPurchaseOrderInvoiceReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ENG,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderInvoiceEVRReport.repx")
                                }
                            },{
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderInvoiceReport.repx")
                                }
                            },
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderInvoiceCNReport.repx")
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
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "POSPurchaseOrderListingCNReport.repx")
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
                    },



                    // -- Report Rest

                    // Restaurant reports

                    {
                        "RESSaleListingInvoiceProfitReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceProfitCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceProfitReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleListingInvoiceNoProfitByDateReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitByDateCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitByDateReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleListingInvoiceNoProfitBySaleReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitBySaleCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitBySaleReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleListingInvoiceNoProfitReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleListingInvoiceProfitByDateReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceProfitByDateCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceProfitByDateReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleListingInvoiceProfitBySellerDateReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceProfitBySellerDateCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingInvoiceProfitBySellerDateReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleListingMovementReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingMovementCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingMovementReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleListingSummaryReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingSummaryCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleListingSummaryReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESDailyClosingInventory80Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESDailyClosingInventory80CNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESDailyClosingInventory80Report.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESDailyClosingInventoryA4Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESDailyClosingInventoryA4CNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESDailyClosingInventoryA4Report.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESInventoryOutOfStockReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESInventoryOutOfStockCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESInventoryOutOfStockReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESPurchaseOrderByDateReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESPurchaseOrderByDateCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESPurchaseOrderByDateReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESPurchaseOrderByInvoiceReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESPurchaseOrderByInvoiceCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESPurchaseOrderByInvoiceReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESPurchaseOrderBySupplierReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESPurchaseOrderBySupplierCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESPurchaseOrderBySupplierReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESPurchaseOrderReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESPurchaseOrderCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESPurchaseOrderReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleInvoice80Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleInvoice80CNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleInvoice80Report.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleInvoiceA4WithProfitReport",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleInvoiceA4WithProfitCNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleInvoiceA4WithProfitReport.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleReceipt58Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleReceipt58CNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleReceipt58Report.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleReceipt80Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleReceipt80CNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleReceipt80Report.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESSaleAuditWithProfitA4Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.ZH_CN,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleAuditWithProfitA4CNReport.repx")
                                }
                            },
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESSaleAuditWithProfitA4Report.repx")
                                }
                            }
                        }
                    },
                    {
                        "RESBZSaleInvoiceA5Report",
                        new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                        {
                            {
                                Languages.KM,
                                new List<(ReportModes reportModes, string reportName)>
                                {
                                    (ReportModes.NormalMode, "RESBZSaleInvoiceA5Report.repx")
                                }
                            }
                        }
                    },
        {
            "RESSaleInvoiceA4Report",
            new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
            {
                {
                    Languages.ZH_CN,
                    new List<(ReportModes reportModes, string reportName)>
                    {
                        (ReportModes.NormalMode, "RESSaleInvoiceA4CNReport.repx")
                    }
                },
                {
                    Languages.KM,
                    new List<(ReportModes reportModes, string reportName)>
                    {
                        (ReportModes.NormalMode, "RESSaleInvoiceA4Report.repx")
                    }
                }
            }
        }
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
            GetReportPath(string reportDirectory, string folderPath, string reportName, Languages language = Languages.KM, ReportModes reportMode = ReportModes.NormalMode)
        {
            var reportVer = reports.ContainsKey(reportName) && reports[reportName].ContainsKey(language)
                                                                && reports[reportName][language].Any(x => x.reportModes == reportMode)
                ? reports[reportName][language].Where(x => x.reportModes.Equals(reportMode)).Select(x => x.reportName).FirstOrDefault() ?? string.Empty
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

    }
}