using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.CodeParser;
using DevExpress.XtraRichEdit.API.Native.Implementation;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Inventory.Expired
{
    public partial class InventoryExpiredReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InventoryExpiredReport()
        {
            InitializeComponent();
        }
        public InventoryExpiredReport(InventoryExpiredDto dto,string reportName)
        {
            LoadLayoutFromXml(reportName);
            var flatten = new List<InventoryExpiredDataSource>();
            if (reportName.Equals("D:\\.NetAPI\\Reports\\Accounting\\InventoryExpiredReport.repx"))
            {
                flatten = dto.Items.GroupBy(x => new { x.Location, x.Category, x.ItemCode, x.Status, x.UnitStock, x.ExpiredDate })
                    .Select(x => new InventoryExpiredDataSource
                    {
                        Category = x.Key.Category,
                        ItemCode = x.Key.ItemCode,
                        UnitStock = x.Key.UnitStock,
                        ExpiredDate = x.Key.ExpiredDate,
                        ItemDesc = x.FirstOrDefault().ItemDesc,
                        ItemDescKh = x.FirstOrDefault().ItemDescKh,
                        Quantity = x.Sum(y => y.Quantity),
                        ImageByte = x.FirstOrDefault().ImageByte,
                        ItemImage = x.FirstOrDefault().ItemImage,
                    }).ToList().OrderByDescending(x => x.Status).ToList();

            }
            if (reportName.Equals("D:\\.NetAPI\\Reports\\Accounting\\InventoryExpiredSummaryReport.repx"))
            {
                flatten = dto.Items.GroupBy(x => new { x.Location, x.Category, x.ItemCode, x.Status, x.UnitStock })
                    .Select(x => new InventoryExpiredDataSource
                    {
                        Category = x.Key.Category,
                        ItemCode = x.Key.ItemCode,
                        UnitStock = x.Key.UnitStock,
                        ExpiredDate = x.FirstOrDefault().ExpiredDate,
                        ItemDesc = x.FirstOrDefault().ItemDesc,
                        ItemDescKh = x.FirstOrDefault().ItemDescKh,
                        Quantity = x.Sum(y => y.Quantity),
                        ImageByte = x.FirstOrDefault().ImageByte,
                        ItemImage = x.FirstOrDefault().ItemImage,
                    }).ToList().OrderByDescending(x => x.Status).ToList();

            }
            var existsValue =
                new List<(string ItemCode, string Location, string Category)>();
            flatten.ForEach(x =>
            {
                if (existsValue.Any(y =>
                        y.ItemCode == x.ItemCode && y.Location == x.Location && y.Category == x.Category ))
                {
                    x.ItemCode = string.Empty;
                    x.ItemDesc = string.Empty;
                    x.ItemDescKh = string.Empty;
                }
                else
                {
                   existsValue.Add((x.ItemCode, x.Location, x.Category));
                }
            });
            dto.Items = flatten;
            this.objectDataSource1.DataSource = dto;
        }

        private void InventoryExpiredReport_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
