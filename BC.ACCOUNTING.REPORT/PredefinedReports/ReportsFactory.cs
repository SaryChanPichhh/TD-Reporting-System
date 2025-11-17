using System;
using System.Collections.Generic;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Inventory;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.Inventory;
using DevExpress.XtraReports.UI;

namespace BC.ACCOUNTING.REPORT.PredefinedReports
{
    public static class ReportsFactory
    {

     
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["DailySaleReport"] = () => new DailySaleReport(),
            ["InventoryReport"] = () => new InventoryReport(),
            ["SaleReport"] = () => new SaleReport(),

        };
    }
}
