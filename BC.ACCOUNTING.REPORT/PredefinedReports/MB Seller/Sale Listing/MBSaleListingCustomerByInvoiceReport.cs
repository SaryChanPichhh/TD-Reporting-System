using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.DTO.MB;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using BC.ACCOUNTING.REPORT.Helper;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Listing
{
    public partial class MBSaleListingCustomerByInvoiceReport : XtraReport
    {
        private int _recordNumber = 0;

        public MBSaleListingCustomerByInvoiceReport()
        {
            InitializeComponent();
        }

        public MBSaleListingCustomerByInvoiceReport(MBSaleListingCustomereDto dto, string reportLayoutPath)
        {
            LoadLayoutFromXml(reportLayoutPath);
            List<CustomerDto> customerInfo = new();
            foreach (var group in dto.Data)
            {
       
                var flattenItems = group.Items
                    .GroupBy(x => new
                    {
                        x.ItemCode,
                        x.TransRef,
                        x.ConvDesc,
                        x.SalePrice,x.Discount,x.DiscountOnInvoice,x.ExchangeRate,x.Cost,x.SetPrice
                    })
                    .Select(x =>
                    {
                        var first = x.FirstOrDefault();
                        return new MBSaleListingCustomerDataSource
                        {   
                            ItemCode = x.Key.ItemCode,
                            ConvDesc = x.Key.ConvDesc,
                            ConvDescKH = first?.ConvDescKH,
                            ItemDesc = first?.ItemDesc,
                            ItemDescKH = first?.ItemDescKH,
                            Discount = x.Key.Discount,
                            DiscountOnInvoice =  x.Key.DiscountOnInvoice,
                            ExchangeRate = x.Key.ExchangeRate,
                            Qty = x.Sum(s => s.Qty),
                            SalePrice = x.Key.SalePrice,
                            TransRef = x.Key.TransRef,
                            Cost = x.Key.Cost,
                            SetPrice = x.Key.SetPrice,
                            Date = first?.Date != null
                                ? Convert.ToDateTime(first.Date).ToString("dd/MM/yyyy")
                                : string.Empty
                        };
                    })
                    .OrderByDescending(x => x.ItemCode)
                    .ToList();
                var seen = new HashSet<(string ItemCode, string TransRef)>();
                int i = 1;
                foreach (var item in flattenItems)
                {
                    var key = (item.ItemCode ?? string.Empty, item.TransRef ?? string.Empty);
                    if (seen.Contains(key))
                    {
                        item.RowNum = "";
                        item.Date = "";
                        item.TransRef = "";
                        item.ItemCode = "";
                        item.ItemDesc = "";
                        item.ItemDescKH = "";
                    }
                    else
                    {
                        item.RowNum = i++.ToString();
                        seen.Add(key);
                    }
                }

                customerInfo.Add(new CustomerDto()
                {
                    CustomerCode = group.CustomerCode,
                    TotalAmount = group.TotalAmount, 
                    TotalPaidAmount = group.TotalPaidAmount, 
                    CustomerName = group.CustomerName, 
                    CustomerNameKH = group.CustomerNameKH,
                    
                    Items = flattenItems,
                });
            }

            dto.Data = customerInfo;
            if(Parameters["DecimalPrecision"] != null)
            {
                Parameters["DecimalPrecision"].Value = dto.DecimalPrecision.GetEnumDescription();
            }
            if(Parameters["SubDecimalPrecision"] != null)
            {
                Parameters["SubDecimalPrecision"].Value = dto.SubDecimalPrecision.GetEnumDescription();
            }
            
            objectDataSource1.DataSource = dto;
            DataSource = objectDataSource1;
        }

        private void GroupHeaderCustomer_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _recordNumber = 0;
        }

        private void xrTableCellRecordNumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (sender is XRControl cell)
            {
                var currentItem = GetCurrentRow() as MBSaleListingCustomerDataSource;

                if (string.IsNullOrEmpty(currentItem?.ItemCode))
                {
                    cell.Text = string.Empty;
                    return;
                }

                _recordNumber++;
                cell.Text = _recordNumber.ToString();
            }
        }
    }
}
