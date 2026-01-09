using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BC.ACCOUNTING.CORE.Enums;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.XtraReports.UI;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order.NO
{
    public partial class NOSaleInvoiceA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        private int _recordNumber = 0;
        public NOSaleInvoiceA4Report()
        {
            InitializeComponent();
        }
        public NOSaleInvoiceA4Report(NOSaleInvoiceDto dto,string reportName)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            
            dto.Items ??= new List<InvoiceItemDataSource>();
            List<InvoiceItemDataSource> invoice = new();
            foreach (var group in dto.Items)
            {
                //var flattenItems = group.UnitConvert
                //    .GroupBy(x => new
                //    {
                //        x.Price,
                //        x.UnitStock
                //    })
                //    .Select(x =>
                //    {
                //        var first = x.FirstOrDefault();
                //        var qty = first?.Qty ?? 0;
                //        var price = x.Key.Price;
                
                foreach (var unitConvert in group.UnitConvert)
                {
                    var extraItems = new List<ExtraInvoiceItemDataSource>();
                    foreach (var extraItem in unitConvert.Extra)
                    {
                        var flatten = extraItem.UnitConvert.GroupBy(x => new
                        {
                            x.Price,
                            x.UnitStock
                        }).Select(x => new ExtraInvoiceItemDataSource
                        {
                            ItemCode = extraItem.ItemCode,
                            ItemDesc = extraItem.ItemDesc,
                            Discount = extraItem.Discount,
                            DiscountPercent = extraItem.DiscountPercent,
                            UnitConvert =
                            [
                                new ExtraItemUnitConvertDataSource
                                {
                                    Price = x.Key.Price,
                                    UnitStock = x.Key.UnitStock,
                                    Qty = x.Sum(y => y.Qty)
                                }
                            ]
                        }).OrderByDescending(x => x.ItemCode).ToList();

                        var IsExists = new Dictionary<string, ExtraInvoiceItemDataSource>();
                        foreach (var item in flatten)
                        {

                            if (IsExists.ContainsKey(item.ItemCode))
                            {
                                item.ItemCode = string.Empty;
                                item.ItemDesc = string.Empty;

                            }
                            else
                            {
                                IsExists.Add(item.ItemCode, new ExtraInvoiceItemDataSource()
                                {
                                    ItemCode = item.ItemCode,
                                    ItemDesc = item.ItemDesc,
                                    UnitConvert = item.UnitConvert
                                });

                            }

                            extraItems.Add(item);
                        }
                    }

                    unitConvert.Extra = extraItems;
                }

                //    Console.WriteLine(extraItems);
                //    return new InvoiceItemDataSource
                //    {
                //        ItemCode = group.ItemCode,
                //        ItemDesc = group.ItemDesc,
                //        UnitConvert =
                //        [
                //            new UnitConvertDataSource
                //                    {
                //                        UnitStock = first?.UnitStock,
                //                        Price = price,
                //                        Qty = qty,
                //                        Combo = dto.ShowCombo ? first.Combo : null,
                //                        Extra = extraItems
                //                    }
                //        ],
                //        Discount = group.Discount,
                //        DiscountPercent = group.DiscountPercent
                //    };
                //})
                //        .OrderByDescending(x => x.ItemCode)
                //        .ToList();

                //    var seen = new HashSet<(string ItemCode, string ItemDesc)>();
                //    foreach (var item in flattenItems)
                //    {
                //        var key = (item.ItemCode ?? string.Empty, item.ItemDesc ?? string.Empty);
                //        if (!seen.Add(key))
                //        {
                //            item.ItemCode = string.Empty;
                //            item.ItemDesc = string.Empty;
                //        }

                //        invoice.Add(item);
                //    }
            }
            LoadLayoutFromXml(reportName);
            if (Parameters["DecimalPrecision"] is not null)
            {
                this.DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if (Parameters["SubDecimalPrecision"] is not null)
            {
                this.SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();
            }

            if (Parameters["Phone"] is not null)
            {
                Console.WriteLine();
            }

            Console.WriteLine();
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
