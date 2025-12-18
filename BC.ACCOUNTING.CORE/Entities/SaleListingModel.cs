using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BC.ACCOUNTING.CORE.Entities
{
    public class SaleListingModel
    {
        public string HeaderTransactionRef { get; set; }
        public string HeaderQuotationNumber { get; set; }
        public string HeaderInvoiceNumber { get; set; } 
        public string HeaderTransactionDate { get; set; }
        public string HeaderTransactionCode { get; set; }
        public string HeaderSaleOrderNumber { get; set; } = string.Empty;
        public string HeaderPrintOrderDate { get; set; }
        public string HeaderSaleOrderDate { get; set; }
        public string HeaderDeliveryDate { get; set; }
        public string HeaderInvoiceDate { get; set; }
        public int HeaderInvoicePeriod { get; set; }
        public string CustomerReference { get; set; }
        public string DeliveryReference { get; set; }
        public string HeaderComments { get; set; }
        public string HeaderPaymentDate { get; set; }
        public decimal HeaderTransactionValue { get; set; }
        public string HeaderAnalysisM0 { get; set; }
        public string HeaderAnalysisM0Description { get; set; } = string.Empty;
        public string HeaderAnalysisM1 { get; set; }
        public string HeaderAnalysisM1Description { get; set; } = string.Empty;
        public string HeaderAnalysisM2 { get; set; }
        public string HeaderAnalysisM2Description { get; set; } = string.Empty;
        public string HeaderAnalysisM3 { get; set; }
        public string HeaderAnalysisM3Description { get; set; } = string.Empty;
        public string HeaderAnalysisM4 { get; set; }
        public string HeaderAnalysisM4Description { get; set; } = string.Empty;
        public string HeaderAnalysisM5 { get; set; }
        public string HeaderAnalysisM5Description { get; set; } = string.Empty;
        public string HeaderAnalysisM6 { get; set; }
        public string HeaderAnalysisM6Description { get; set; } = string.Empty;
        public string HeaderAnalysisM7 { get; set; }
        public string HeaderAnalysisM7Description { get; set; } = string.Empty;
        public string HeaderAnalysisM8 { get; set; }
        public string HeaderAnalysisM8Description { get; set; } = string.Empty;
        public string HeaderAnalysisM9 { get; set; }
        public string HeaderAnalysisM9Description { get; set; } = string.Empty;
        public string HeaderQuotationExpiry { get; set; }
        public string HeaderQuotatioPeriod { get; set; } = string.Empty;
        public string HeaderQuotationDate { get; set; }
        public string HeaderQuotationStatus { get; set; }
        public string CustomerLookup { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerAddress3 { get; set; }
        public string CustomerAddress4 { get; set; }
        public string CustomerAddress5 { get; set; }
        public string CustomerTelephone { get; set; }
        public string CustomerFax { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerWebPage { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerComment { get; set; }
        public string CustomerSecondComment { get; set; }
        public string CustomerNameKhmer { get; set; }
        public string CustomerAddress1Khmer { get; set; }
        public string CustomerAddress2Khmer { get; set; }
        public string DeliveryCode { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress1 { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string DeliveryAddress3 { get; set; }
        public string DeliveryAddress4 { get; set; }
        public string DeliveryAddress5 { get; set; }
        public string DeliveryPhone { get; set; } = string.Empty;
        public string DeliveryFax { get; set; }
        public string DeliveryEmail { get; set; } = string.Empty;
        public string DeliveryWebPage { get; set; }
        public string DeliveryContact { get; set; }
        public string DeliveryComment { get; set; }
        public string DeliverySecondComment { get; set; }
        public string DeliveryNameKhmer { get; set; }
        public string DeliveryAddress1Khmer { get; set; }
        public string DeliveryAddress2Khmer { get; set; }
        public string DetailLineNumber { get; set; }
        public string DetailDescription { get; set; }
        public string DetailDueDate { get; set; }
        public decimal Value_1  { get; set; }
        public decimal Value_2  { get; set; }
        public decimal Value_3  { get; set; }
        public decimal Value_4  { get; set; }
        public decimal Value_5  { get; set; }
        public decimal Value_6  { get; set; }
        public decimal Value_7  { get; set; }
        public decimal Value_8  { get; set; }
        public decimal Value_9  { get; set; }
        public decimal Value_10  { get; set; }
        public decimal Value_11  { get; set; }
        public decimal Value_12  { get; set; }
        public decimal Value_13  { get; set; }
        public decimal Value_14  { get; set; }
        public decimal Value_15  { get; set; }
        public decimal Value_16  { get; set; }
        public decimal Value_17  { get; set; }
        public decimal Value_18  { get; set; }
        public decimal Value_19  { get; set; }
        public decimal Value_20  { get; set; }  
        public decimal SaleQuantity { get; set; }
        public decimal StockQuantity { get; set; }
        public decimal TotalValue { get; set; }
        public decimal ReportConvertStockQuantity { get; set; }
        public string ReportConvertUnit { get; set; }
        public string DetailDeliveryDate { get; set; }
        public string DetailAccountCode { get; set; }
        public string DetailUnitOfSale { get; set; }
        public string DetailUnitOfDesc { get; set; } = string.Empty;
        public decimal UnitOfSaleFactor { get; set; }
        public decimal CostValue { get; set; }
        public string DetailAnalysisM0Description { get; set; } = string.Empty;
        public string DetailAnalysisM0 { get; set; }
        public string DetailAnalysisM1Description { get; set; } = string.Empty;
        public string DetailAnalysisM1 { get; set; }
        public string DetailAnalysisM2Description { get; set; } = string.Empty;
        public string DetailAnalysisM2 { get; set; }
        public string DetailAnalysisM3Description { get; set; } = string.Empty;
        public string DetailAnalysisM3 { get; set; }  
        public string DetailAnalysisM4Description { get; set; } = string.Empty;
        public string DetailAnalysisM4 { get; set; }
        public string DetailAnalysisM5Description { get; set; } = string.Empty;
        public string DetailAnalysisM5 { get; set; }
        public string DetailAnalysisM6Description { get; set; } = string.Empty;
        public string DetailAnalysisM6 { get; set; }
        public string DetailAnalysisM7Description { get; set; } = string.Empty;
        public string DetailAnalysisM7 { get; set; }
        public string DetailAnalysisM8Description { get; set; } = string.Empty;
        public string DetailAnalysisM8 { get; set; }
        public string DetailAnalysisM9Description { get; set; } = string.Empty;
        public string DetailAnalysisM9 { get; set; }
        public string DetailLineReference { get; set; }
        public string DetailItemCode { get; set; }
        public string ItemBarCode { get; set; }
        public string ItemDescription { get; set; }
        public string ItemLookup { get; set; }
        public decimal ItemPrice1 { get; set; }
        public decimal ItemPrice2 { get; set; }
        public decimal ItemPrice3 { get; set; }
        public decimal ItemPrice4 { get; set; }
        public decimal ItemPrice5 { get; set; }
        public string ItemLevel { get; set; }
        public string ItemType { get; set; }
        public decimal ItemCost { get; set; }
        public string ItemUnitOfStock { get; set; }
        public decimal ItemUnitOfWeight { get; set; }
        public string ItemUpdatePrice { get; set; }
        public string ItemCustom1 { get; set; }
        public string ItemCustom2 { get; set; }
        public string ItemCustom3 { get; set; }
        public string ItemCustom4 { get; set; }
        public string ItemCustom5 { get; set; }
        public string ItemCustom6 { get; set; }
        public string ItemCustom7 { get; set; }
        public string ItemCustom8 { get; set; }
        public string ItemCustom9Khmer{ get; set; }
        public string ItemCustom10Khmer{ get; set; }
        public string DetailLocationCode { get; set; } = string.Empty;
        public string LocationName { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationAddress3 { get; set; }
        public string LocationPhone1 { get; set; } = string.Empty;
        public string LocationPhone2 { get; set; } = string.Empty;
        public string LocationFax { get; set; }
        public string LocationComment { get; set; }
        public string LocationSecondComment { get; set; }

    }
}
