using BC.ACCOUNTING.REPORT.DataSources;
using DevExpress.PivotGrid.PivotTable;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.Helper
{
    public static class ReportHelper
    {
        
        #region Initialization Report+

        private static
            Dictionary<string, Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>> Reports = new ()
                 {
                     {
                         "DailyClosingInventoryDetailA4Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                Languages.ENG,
                                 [(ReportModes.NormalMode, "DailyClosingInventoryDetailA4EngReport.repx")]
                             },
                             {
                Languages.KM,
                                 [
                                     (ReportModes.NormalMode, "DailyClosingInventoryDetailA4Report.repx"),
                                 ]
                             },
                             {
                Languages.ZH_CN,
                                 [
                                     (ReportModes.NormalMode, "DailyClosingInventoryDetailA4CNReport.repx")
                                 ]
                             }
        }
    }, 
                     {
                         "POSSaleInvoiceReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
            Languages.ENG,
                                 [(ReportModes.NormalMode, "POSSaleInvoiceEVReport.repx")]
                             },
                             {
            Languages.KM,
                                 [
                                     (ReportModes.DeliveryFeeMode, "POSSaleInvoiceWithDeliveryFeeReport.repx"),
                                     (ReportModes.NormalMode, "POSSaleInvoiceReport.repx")
                                 ]
                             },
                             {
            Languages.ZH_CN,
                                 [
                                     (ReportModes.DeliveryFeeMode, "POSSaleInvoiceWithDeliveryFeeCNReport.repx"),
                                     (ReportModes.NormalMode, "POSSaleInvoiceCNReport.repx")
                                 ]
                             }
    }
},
                     {
    "AA118SaleInvoiceA5Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "AA118SaleInvoiceA5Report.repx")]
                             },
                             {
                                 Languages.KM,
                                 [
                                     (ReportModes.DeliveryFeeMode, "AA118SaleInvoiceA5Report.repx"),
                                     (ReportModes.NormalMode, "AA118SaleInvoiceA5Report.repx")
                                 ]
                             },
                             {
                                 Languages.ZH_CN,
                                 [
                                     (ReportModes.DeliveryFeeMode, "AA118SaleInvoiceA5Report.repx"),
                                     (ReportModes.NormalMode, "AA118SaleInvoiceA5Report.repx")
                                 ]
                             }
                         }
                     },
                     {
    "AKASaleInvoiceA5Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "AKASaleInvoiceA5Report.repx")]
                             },
                             {
                                 Languages.KM,
                                 [
                                     (ReportModes.DeliveryFeeMode, "AKASaleInvoiceA5Report.repx"),
                                     (ReportModes.NormalMode, "AKASaleInvoiceA5Report.repx")
                                 ]
                             },
                             {
                                 Languages.ZH_CN,
                                 [
                                     (ReportModes.DeliveryFeeMode, "AKASaleInvoiceA5Report.repx"),
                                     (ReportModes.NormalMode, "AKASaleInvoiceA5Report.repx")
                                 ]
                             }
                         }
                     },
                     {
    "POSSaleInvoiceA5Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSSaleInvoiceA5Report.repx")]
                             },
                             {
                                 Languages.KM,
                                 [
                                     (ReportModes.DeliveryFeeMode, "POSSaleInvoiceA5Report.repx"),
                                     (ReportModes.NormalMode, "POSSaleInvoiceA5Report.repx")
                                 ]
                             },
                             {
                                 Languages.ZH_CN,
                                 [
                                     (ReportModes.DeliveryFeeMode, "POSSaleInvoiceA5CNReport.repx"),
                                     (ReportModes.NormalMode, "POSSaleInvoiceA5CNReport.repx")
                                 ]
                             },
                         }
                     },
                     {
    "A4DailyClosingInventoryReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "A4DailyClosingInventoryEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "A4DailyClosingInventoryReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "A4DailyClosingInventoryCNReport.repx")]
                             },
                         }
                     },
                     {
    "DailyClosingInventoryReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "DailyClosingInventoryEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "DailyClosingInventoryReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "DailyClosingInventoryCNReport.repx")]
                             },
                         }
                     },
        
                     {
    "DailyClosingReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "DailyClosingEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "DailyClosingReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "DailyClosingCNReport.repx")]
                             },
                         }
                     },
                     {
    "CustomerOrderReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "CustomerOrderEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "CustomerOrderReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "CustomerOrderCNReport.repx")]
                             },
                         }
                     },
                     {
    "POSSaleListingReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSSaleListingEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "POSSaleListingReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "POSSaleListingCNReport.repx")]
                             },
                         }
                     },
                     {
    "SaleListingByInvoiceReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "SaleListingByInvoiceEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [
                                     (ReportModes.NormalMode, "SaleListingByInvoiceReport.repx"),
                                     (ReportModes.DeliveryFeeMode, "SaleListingByInvoiceWithDeliveryFeeReport.repx")
                                 ]
                             },
                             {
                                 Languages.ZH_CN,
                                 [
                                     (ReportModes.NormalMode, "SaleListingByInvoiceCNReport.repx"),
                                     (ReportModes.DeliveryFeeMode, "SaleListingByInvoiceWithDeliveryFeeCNReport.repx")
                                 ]
                             },
                         }
                     },
                     {
    "SaleListingMovementReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "SaleListingMovementEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "SaleListingMovementReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "SaleListingMovementCNReport.repx")]
                             },
                         }
                     },
                     {
    "IUInventoryAuditA4Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "IUInventoryAuditA4EVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "IUInventoryAuditA4Report.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "IUInventoryAuditA4CNReport.repx")]
                             },
                         }
                     },
                     {
    "POSInventoryOutOfStockReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSInventoryOutOfStockEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "POSInventoryOutOfStockReport.repx")]
                             },
                             {
                             Languages.ZH_CN,
                             [(ReportModes.NormalMode, "POSInventoryOutOfStockCNReport.repx")]
                             },
                         }
                     },
                     {
    "POSSaleListingSummaryReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSSaleListingSummaryEVReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "POSSaleListingSummaryCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [
                                     (ReportModes.NormalMode, "POSSaleListingSummaryReport.repx"),
                                     (ReportModes.DeliveryFeeMode, "SaleListingByInvoiceWithDeliveryFeeReport.repx")
                                 ]
                             },
                         }
                     },
                     {
    "SaleListingByDateReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "SaleListingByDateEVReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "SaleListingByDateCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [
                                     (ReportModes.NormalMode, "SaleListingByDateReport.repx"),
                                     (ReportModes.DeliveryFeeMode, "SaleListingByDateWithDeliveryFeeReport.repx")
                                 ]
                             },
                         }
                     },
                     {
    "SaleListingBySellerReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "SaleListingBySellerEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [
                                     (ReportModes.NormalMode, "SaleListingBySellerReport.repx"),
                                     (ReportModes.DeliveryFeeMode, "SaleListingBySellerWithDeliveryFeeReport.repx")
                                 ]
                             },
                             {
                             Languages.ZH_CN,
                             [
                                 (ReportModes.NormalMode, "SaleListingBySellerCNReport.repx"),
                                 (ReportModes.DeliveryFeeMode, "SaleListingBySellerWithDeliveryFeeCNReport.repx")
                             ]
                             },
                         }
                     },
                     {
    "SaleListingBySellerNoProfitReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "SaleListingBySellerNoProfitEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "SaleListingBySellerNoProfitReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "SaleListingBySellerNoProfitCNReport.repx")]
                             },
                         }
                     },
                     {
    "SaleListingByInvoiceNoProfitReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "SaleListingByInvoiceNoProfitEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "SaleListingByInvoiceNoProfitReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "SaleListingByInvoiceNoProfitCNReport.repx")]
                             },
                         }
                     },
                     {
    "POSPurchaseOrderByDateReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderByDateEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderByDateReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderByDateCNReport.repx")]
                             },
                         }
                     },
                     {
    "POSPurchaseOrderByInvoiceReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderByInvoiceEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderByInvoiceReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderByInvoiceCNReport.repx")]
                             },
                         }
                     },
                     {
    "POSPurchaseOrderBySupplierReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderBySupplierEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderBySupplierReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderBySupplierCNReport.repx")]
                             },
                         }
                     },
                     {
    "POSPurchaseOrderInvoiceReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderInvoiceEVRReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderInvoiceReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderInvoiceCNReport.repx")]
                             },
                         }
                     },
                     {
    "POSPurchaseOrderListingReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderListingEVReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderListingReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "POSPurchaseOrderListingCNReport.repx")]
                             },
                         }
                     },
                     {
    "POSPOListingReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "POSPOListingEngReport.repx")]
                             },{
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "POSPOListingCNReport.repx")]
                             },{
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "POSPOListingReport.repx")]
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
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitCNReport.repx")]
                             },
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitEngReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleListingInvoiceNoProfitByDateReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitByDateEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitByDateCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitByDateReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleListingInvoiceNoProfitBySaleReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitBySaleEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitBySaleCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitBySaleReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleListingInvoiceNoProfitReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceNoProfitReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleListingInvoiceProfitByDateReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitByDateEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitByDateCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitByDateReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleListingInvoiceProfitBySellerReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitBySellerEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitBySellerCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleListingInvoiceProfitBySellerReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleListingMovementReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleListingMovementEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleListingMovementCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleListingMovementReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleListingSummaryReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleListingSummaryEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleListingSummaryCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleListingSummaryReport.repx")]
                             }
                         }
                     },
                     {
    "RESDailyClosingInventory80Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESDailyClosingInventory80CNReport.repx")]
                             },
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESDailyClosingInventory80EngReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESDailyClosingInventory80Report.repx")]
                             }
                         }
                     },
                     {
    "RESDailyClosingInventoryA4Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESDailyClosingInventoryA4CNReport.repx")]
                             },
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESDailyClosingInventoryA4EngReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESDailyClosingInventoryA4Report.repx")]
                             }
                         }
                     },
                     {
    "RESInventoryOutOfStockReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESInventoryOutOfStockCNReport.repx")]
                             },
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESInventoryOutOfStockEngReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESInventoryOutOfStockReport.repx")]
                             }
                         }
                     },
                     {
    "RESPurchaseOrderByDateReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderByDateEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderByDateCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderByDateReport.repx")]
                             }
                         }
                     },
                     {
    "RESPurchaseOrderByInvoiceReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderByInvoiceEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderByInvoiceCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderByInvoiceReport.repx")]
                             }
                         }
                     },
                     {
    "RESPurchaseOrderBySupplierReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderBySupplierEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderBySupplierCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderBySupplierReport.repx")]
                             }
                         }
                     },
                     {
    "RESPurchaseOrderReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESPurchaseOrderReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleInvoice80Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleInvoice80EngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleInvoice80CNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleInvoice80Report.repx")]
                             }
                         }
                     },
                     {
    "RESSaleInvoiceA4WithProfitReport",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleInvoiceA4WithProfitEngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleInvoiceA4WithProfitCNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleInvoiceA4WithProfitReport.repx")]
                             }
                         }
                     },
                     {
    "RESSaleReceipt58Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleReceipt58EngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleReceipt58CNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleReceipt58Report.repx")]
                             }
                         }
                     },
                     {
    "RESSaleReceipt80Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleReceipt80EngReport.repx")]
                             },
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleReceipt80CNReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleReceipt80Report.repx")]
                             }
                         }
                     },
                     {
    "RESSaleAuditWithProfitA4Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.ZH_CN,
                                 [(ReportModes.NormalMode, "RESSaleAuditWithProfitA4CNReport.repx")]
                             },
                             {
                                 Languages.ENG,
                                 [(ReportModes.NormalMode, "RESSaleAuditWithProfitA4ENGReport.repx")]
                             },
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESSaleAuditWithProfitA4Report.repx")]
                             }
                         }
                     },
                     {
    "RESBZSaleInvoiceA5Report",
                         new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
                         {
                             {
                                 Languages.KM,
                                 [(ReportModes.NormalMode, "RESBZSaleInvoiceA5Report.repx")]
                             }
                         }
                     },
         {
    "RESSaleInvoiceA4Report",
             new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>
             {
                 {
                     Languages.ENG,
                     [(ReportModes.NormalMode, "RESSaleInvoiceA4EngReport.repx")]
                 },
                 {
                     Languages.ZH_CN,
                     [(ReportModes.NormalMode, "RESSaleInvoiceA4CNReport.repx")]
                 },
                 {
                     Languages.KM,
                     [(ReportModes.NormalMode, "RESSaleInvoiceA4Report.repx")]
                 }
             }
         }
                 };
        #endregion
//public static void Initialize(
//            Dictionary<string, Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>> reports)
//        {
//            Reports = reports;
//        }
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
                { "AA118SaleInvoiceA5Report", (16, 46, 18, 23, 27) },
            };
        #endregion

        public static string
            GetReportPath(string reportDirectory, string? folderPath, string reportName,
                Languages language = Languages.KM, ReportModes reportMode = ReportModes.NormalMode)
        {

            Console.WriteLine(Reports);
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

        private static int _rowCount = 0;
        private static bool _firstBreakDone = false;
        private static int totalRow = 0;
        public static void Detail_BeforePrint(object sender, CancelEventArgs e,int firstPageLimit,int firstPageFullLimit
            , int secondPageLimit, int secondPageFullLimit )
        {
            var detail  = sender as DetailBand;
            _rowCount++;
            var threshold = _firstBreakDone ? firstPageFullLimit : firstPageLimit;

            if (_rowCount >= threshold && _rowCount == totalRow)
            {
                detail.PageBreak = PageBreak.AfterBand;
                _rowCount = 0;
                _firstBreakDone = true;
            }
            else if (_rowCount >= firstPageFullLimit)
            {
                if (!_firstBreakDone)
                {
                    detail.PageBreak = PageBreak.AfterBand;
                    _firstBreakDone = true;
                    totalRow -= _rowCount;
                    _rowCount = 0;
                }
            }
            else
            {
                detail.PageBreak = PageBreak.None;
            }
            if ((_firstBreakDone && _rowCount >= secondPageLimit && totalRow == _rowCount) || (_firstBreakDone && _rowCount >= secondPageFullLimit))
            {
                detail.PageBreak = PageBreak.AfterBand;
                _rowCount = 0;
            }

        }

        public static async Task<TResponse?> GetDataFromJson<TResponse>(string jsonFilePath, string jsonFileName, string jsonKey)
        {
            if (string.IsNullOrEmpty(jsonFilePath) || string.IsNullOrEmpty(jsonFileName))
                return default;

            var jsonPath = Path.Combine(jsonFilePath, "JsonFiles", jsonFileName);
            if (!File.Exists(jsonPath))
            {
                jsonPath = Path.Combine(jsonFilePath, "jsonFiles", jsonFileName);
                if (!File.Exists(jsonPath))
                    return default;
            }

            try
            {
                var jsonString = await File.ReadAllTextAsync(jsonPath);
                var token = JToken.Parse(jsonString);

                if (token is JObject obj)
                {
                    if (string.IsNullOrWhiteSpace(jsonKey))
                        return obj.ToObject<TResponse>();

                    var value = obj[jsonKey];
                    return value != null ? value.ToObject<TResponse>() : default;
                }

                if (token is JArray)
                {
                    return token.ToObject<TResponse>();
                }

                return default;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Invalid JSON: {ex.Message}");
                return default;
            }
        }

    }
    public class AppJson
    {
        public List<ReportChangeSetting> InitPosReportForUrgentCustReportChange { get; set; } = [];
    }

    public class ReportChangeSetting
    {
        public string ShopName { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
