using BC.ACCOUNTING.CORE.Enums;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.Helper;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using BC.ACCOUNTING.REPORT.Helper.ExpressionFunction;
using DevExpress.Drawing;
using FontFamily = System.Drawing.FontFamily;

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
            dto.Payments ??= new List<PaymentDataSource>();
            decimal grandTotal = -0;
            foreach (var group in dto.Items)
            {

                decimal itemGroupSubTotal = 0;

                foreach (var unitConvert in group.UnitConvert)
                {
                    var lineTotal = (unitConvert.Qty * unitConvert.Price);
                    var discountAmount = (unitConvert.Price * (group.DiscountPercent / 100));
                    itemGroupSubTotal += (lineTotal - (unitConvert.Qty * discountAmount));
                    grandTotal += lineTotal;
                    if (unitConvert.Extra != null)
                    {
                        var processedExtras = new List<ExtraInvoiceItemDataSource>();

                        foreach (var extraItem in unitConvert.Extra)
                        {
                            decimal extraSum = extraItem.UnitConvert.Sum(e => e.Qty * e.Price);
                            itemGroupSubTotal += extraSum;
                            grandTotal+=extraSum;
                            var flattenExtra = extraItem.UnitConvert.GroupBy(x => new
                            {
                                x.Price,
                                x.UnitStock 
                            }).Select(x => new ExtraInvoiceItemDataSource
                            {
                                ItemCode = extraItem.ItemCode,
                                ItemDesc = extraItem.ItemDesc,
                                Discount = extraItem.Discount,
                                DiscountPercent = extraItem.DiscountPercent,
                                UnitConvert = new List<ExtraItemUnitConvertDataSource>
                                {
                                    new ExtraItemUnitConvertDataSource
                                    {
                                        Price = x.Key.Price,
                                        UnitStock = x.Key.UnitStock,
                                        Qty = x.Sum(y => y.Qty)
                                    }
                                }
                            }).ToList();

                            var isExists = new Dictionary<string, ExtraInvoiceItemDataSource>();
                            foreach (var fItem in flattenExtra)
                            {
                                if (isExists.ContainsKey(fItem.ItemCode))
                                {
                                    fItem.ItemCode = string.Empty;
                                    fItem.ItemDesc = string.Empty;
                                }
                                else
                                {
                                    isExists.Add(fItem.ItemCode, fItem);
                                }

                                processedExtras.Add(fItem);
                            }
                        }

                        unitConvert.Extra = processedExtras;
                    }
                }

                group.SubTotal = itemGroupSubTotal;

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
            if (Parameters["CurrencySymbol"] is not null)
            {
                this.CurrencySymbol.Value = dto.CurrencySymbol;
            }
            if (Parameters["SubCurrencySymbol"] is not null)
            {
                this.SubCurrencySymbol.Value = dto.SubCurrencySymbol;
            }
            if (Parameters["InvoiceStatusDesc"] is not null)
            {
                this.InvoiceStatusDesc.Value = dto.InvoiceStatus.GetEnumDescription();
            }
            if (Parameters["SubTotal_prm"] is not null)
            {
                this.SubTotal_prm.Value = grandTotal;
            }
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
