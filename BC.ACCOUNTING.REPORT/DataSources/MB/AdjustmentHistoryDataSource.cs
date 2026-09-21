namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    
    //    {
    //    "IsShowCost": true,
    //    "ExportFormat": 1,
    //    "reportName": "IUInventoryAuditA4Report",
    //    "ShopName": "TD-Technology",
    //    "ShopImage": "",
    //    "DbCode": "AA053",
    //    "PrintDate": "2026-09-10T14:08:33.330949",
    //    "Items": [
    //    {
    //        "WAR_CODE": "000001",
    //        "WAR_NAME": "Kawaii Store",
    //        "MOV_DATE": "09/10/2026",
    //        "MOV_REF": "ADJ+26090001",
    //        "ITEM_CODE": "0239",
    //        "ITEM_BCODE": "0239",
    //        "ITEM_DESC": "ambi pur",
    //        "QUANTITY": 8,
    //        "COST": 1,
    //        "TOTAL": 8,
    //        "USER_NAME": "mini_mart",
    //        "USER_ID": 4363
    //    }
    //    ],
    //    "CurrencySymbol": "$"
    //}

    public class AdjustmentHistoryDataSource
    {
        public string WareCode { get; set; } = string.Empty;
        public string Warehouse { get; set; } = string.Empty;
        public string AdjustmentDate { get; set; } = string.Empty;
        public string AdjustmentRef { get; set; } = string.Empty;
        public string ItemCode { get; set; } = string.Empty;
        public string ItemBarCode { get; set; } = string.Empty;
        public string ItemDesc { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double Total { get; set; }   
        public string AdjustedBy { get; set; } = string.Empty;

    }
}
