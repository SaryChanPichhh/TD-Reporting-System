using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.DTO.MB;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order
{
    public partial class NOSaleInvoiceA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        private int _recordNumber = 0;
        public NOSaleInvoiceA4Report()
        {
            InitializeComponent();
        }public NOSaleInvoiceA4Report(NOSaleInvoiceDto dto,string reportName)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            dto.Items ??= new List<InvoiceItemDataSource>();
            List<InvoiceItemDataSource> invoice = new();
            foreach (var group in dto.Items)
            {
                var flattenItems = group.UnitConvert
                    .GroupBy(x => new
                    {
                        x.Price,
                        x.UnitStock
                    })
                    .Select(x =>
                    {
                        var first = x.FirstOrDefault();
                        var qty = first?.Qty ?? 0;
                        var price = x.Key.Price;

                        return new InvoiceItemDataSource
                        {
                            ItemCode = group.ItemCode,
                            ItemDesc = group.ItemDesc,
                            UnitConvert = new List<UnitConvertDataSource>
                            {
                                new UnitConvertDataSource
                                {
                                    UnitStock = first?.UnitStock,
                                    Price = price,
                                    Qty = qty,
                                    Combo = dto.ShowCombo ? first.Combo : null
                                }
                            },
                            Discount = group.Discount,
                            DiscountPercent = group.DiscountPercent
                        };
                    })
                    .OrderByDescending(x => x.ItemCode)
                    .ToList();

                var seen = new HashSet<(string ItemCode, string ItemDesc)>();
                foreach (var item in flattenItems)
                {
                    var key = (item.ItemCode ?? string.Empty, item.ItemDesc ?? string.Empty);
                    if (seen.Contains(key))
                    {
                        item.ItemCode = string.Empty;
                        item.ItemDesc = string.Empty;
                    }
                    else
                    {
                        seen.Add(key);
                    }

                    invoice.Add(item);
                }
            }

            var rowNum = 1;
            foreach (var item in invoice)
            {
                item.RowNum = !string.IsNullOrEmpty(item.ItemCode) ? rowNum++.ToString() : string.Empty;
            }

            dto.Items = invoice;

            LoadLayoutFromXml(reportName);
            objectDataSource1.DataSource = dto;
            DataSource = objectDataSource1;
            if(xrTableCellRecordNumber != null)
                xrTableCellRecordNumber.BeforePrint += xrTableCellRecordNumber_BeforePrint;
        }
        private void GroupHeaderCustomer_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _recordNumber = 0;
        }

        private void xrTableCellRecordNumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void xrTableCellRecordNumber_BeforePrint(object sender, CancelEventArgs e)
        {
            if (sender is XRControl cell)
            {
                var currentItem = GetCurrentRow() as InvoiceItemDataSource;

                if (string.IsNullOrEmpty(currentItem?.ItemCode))
                {
                    cell.Text = string.Empty;
                    return;
                }

                cell.Text = currentItem.RowNum;
            }
        }

        private void xrLabel7_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
