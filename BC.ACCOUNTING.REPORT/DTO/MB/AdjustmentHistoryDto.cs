using BC.ACCOUNTING.REPORT.DataSources.MB;

namespace BC.ACCOUNTING.REPORT.DTO.MB
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


    public record AdjustmentHistoryDto : ReportDto
    {
        public bool IsShowCost { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public string ShopImage { get; set; } = string.Empty;
        public DateTime PrintDate { get; set; }
        public List<AdjustmentHistoryDataSource> Items { get; set; } = [];

    }
}
