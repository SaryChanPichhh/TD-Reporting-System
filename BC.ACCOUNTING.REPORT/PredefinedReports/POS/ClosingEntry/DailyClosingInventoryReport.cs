using BC.ACCOUNTING.REPORT.DataSources.POS;
using BC.ACCOUNTING.REPORT.Helper.ConfigJsonFile;
using BC.ACCOUNTING.REPORT.Models.MB;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using DevExpress.CodeParser;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ClosingEntry
{
    public partial class DailyClosingInventoryReport : XtraReport
    {
        private List<PaymentMethodDataSource> Payments { get; set; } = [];
        private List<DailyClosingPaymentDataSource> PaymentMethod { get; set; } = [];
        public DailyClosingInventoryReport()
        {
            InitializeComponent();
        }
        public DailyClosingInventoryReport(DailyClosing80Dto inventoryDto, string reportName,GroupByKey branches)
        {
            this.LoadLayoutFromXml(reportName);
            
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = inventoryDto.DecimalPrecision.GetEnumDescription();
            if (xrLabel15 is not null)
                this.xrLabel15.BeforePrint += xrLabel15_BeforePrint_80;
            if (xrLabel16 is not null)
                this.xrLabel16.BeforePrint += xrLabel16_BeforePrint_80;
            if (branches is not null)
                if (inventoryDto.DbCode.Equals(branches.DbCode??string.Empty))
                {
                    MappingCategoriesData(inventoryDto, branches);
                }
            var data = ConvertFromDtoToModel(inventoryDto);
            objectDataSource1.DataSource = data;
            this.DataSource = objectDataSource1;
            PaymentMethod = data.Payments;
        }
        public DailyClosingInventoryReport(DailyClosingInventoryDto inventoryDto, string reportName, GroupByKey branches)
        {
            this.LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = inventoryDto.DecimalPrecision.GetEnumDescription();
            if(ReportHeader1 is not null)
                this.ReportHeader1.BeforePrint += ReportHeader1_BeforePrint;
            if (Detail2 is not null)
                this.Detail2.BeforePrint += Detail2_BeforePrint;
            if (ReportFooter2 is not null)
                this.ReportFooter2.BeforePrint += ReportFooter2_BeforePrint;
            if (xrLabel15 is not null)
                this.xrLabel15.BeforePrint += xrLabel15_BeforePrint;
            if (xrLabel16 is not null)
                this.xrLabel16.BeforePrint += xrLabel16_BeforePrint;
            if (branches is not null)
                if (inventoryDto.DbCode.Equals(branches.DbCode))
                {
                    MappingCategoriesData(inventoryDto, branches);
                }
            objectDataSource1.DataSource = inventoryDto;
            this.DataSource = objectDataSource1;
            Payments = inventoryDto.Payments;
        }

        public DailyClosingInventoryReport(DailyClosingInventoryByCategoryDto inventoryDto, string reportName, GroupByKey branches)
        {
            this.LoadLayoutFromXml(reportName);
            if (this.Parameters["DecimalPrecision"] is not null)
                this.DecimalPrecision.Value = inventoryDto.DecimalPrecision.GetEnumDescription();
            if (ReportHeader1 is not null)
                this.ReportHeader1.BeforePrint += ReportHeader1_BeforePrint_ByCategory;
            if (Detail2 is not null)
                this.Detail2.BeforePrint += Detail2_BeforePrint_ByCategory;
            if (ReportFooter2 is not null)
                this.ReportFooter2.BeforePrint += ReportFooter2_BeforePrint_ByCategory;
            if (xrLabel15 is not null)
                this.xrLabel15.BeforePrint += xrLabel15_BeforePrint_ByCategory;
            if (xrLabel16 is not null)
                this.xrLabel16.BeforePrint += xrLabel16_BeforePrint_ByCategory;
            if (branches is not null)
                if (inventoryDto.DbCode.Equals(branches.DbCode))
                {
                    MappingCategoriesData(inventoryDto, branches);
                }


            objectDataSource1.DataSource = inventoryDto;
            this.DataSource = objectDataSource1;
            Payments = inventoryDto.Payments;
        }

        #region Mapping Categories Data

        private static void MappingCategoriesData(dynamic data, GroupByKey jsonFile)
        {

            switch (data)
            {
                case DailyClosingInventoryByCategoryDto byCategory:
                    
                    byCategory.Items.ForEach(x =>
                    {
                        if (x.CategoryCode != null && !jsonFile.Values.Any(z=>z.Equals(x.CategoryCode)))
                        {
                            x.CategoryDesc = "ទំនិញទូទៅ";
                            x.CategoryCode = "1";
                        }
                    });

                    break;
                case DailyClosingInventoryDto byInventory:
                    byInventory.Items.ForEach(x =>
                    {
                        if (x.CategoryCode != null && !jsonFile.Values.Any(z => z.Equals(x.CategoryCode.ToString())))
                        {
                            x.CategoryDesc = "ទំនិញទូទៅ";
                            x.CategoryCode = 1;
                        }
                    });
                    break;
                case DailyClosing80Dto byInventoryEightyPaper:
                    byInventoryEightyPaper.Items.ForEach(x =>
                    {
                        if (x.CategoryCode != null && !jsonFile.Values.Any(z => z.Equals(x.CategoryCode.ToString())))
                        {
                            x.CategoryDesc = "ទំនិញទូទៅ";
                            x.CategoryCode = 1;
                        }
                    });

                    break;
            }
        }


        #endregion

        #region Set Group Feield
        private static ClosingInventoryCategoryModel ConvertFromDtoToModel(DailyClosing80Dto model)
        {
            var expense = model.Expense;
            var convert = new ClosingInventoryCategoryModel
            {
                DbCode = model.DbCode,
                ReportName = model.ReportName,
                ExportFormat = model.ExportFormat,
                Language = model.Language,
                CurrencySymbol = model.CurrencySymbol,
                DecimalPrecision = model.DecimalPrecision,
                SubCurrencySymbol = model.SubCurrencySymbol,
                SubDecimalPrecision = model.SubDecimalPrecision,
                CashChange = model.CashChange is not null ? model.CashChange.ToString() : "",
                Dates = model.Dates,
                Discount = model.Discount is not null ? model.Discount.ToString() :"",
                Duration = model.Duration,
                ExchangeRate = model.ExchangeRate is not null ? model.ExchangeRate.ToString() : "",
                Expense = model.Expense is not null ? model.Expense.ToString() : "",
                ExpenseRiel = model.ExpenseRiel is not null ? model.ExpenseRiel.ToString() : "",
                PrintDate = model.PrintDate,
                Seller = model.Seller,
                Subtotal = model.Subtotal.ToString() ?? "",
                TotalDollar = model.TotalDollar,
                TotalPrice = model.TotalPrice,
                TotalRiel = model.TotalRiel,
                Vat = model.Vat.ToString(),
                Items = model.Items.Select(x=> new ItemDataSource()
                {
                    CategoryCode = x.CategoryCode.ToIntSafe(),
                    CategoryDesc = x.CategoryDesc,
                    Price = x.Price.ToDecimalSafe(),
                    DiscountPrice = x.DiscountPrice.ToDecimalSafe(),
                    FinalPrice = x.FinalPrice.ToDecimalSafe(),
                    ItemCode = x.ItemCode.ToStringSafe(),
                    Total = x.Total.ToDecimalSafe(),
                    Qty = x.Qty.ToIntSafe(),
                    ItemDesc = x.ItemDesc,
                }).ToList(),
                Expenses = model.Expenses,
                Payments = model.Payments
            };
            return convert;
        }
        #endregion
        #region Report A4

        private void ReportHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosingInventoryDto;
            e.Cancel = data?.Payments == null || !data.Payments.Any();
        }

        private void Detail2_BeforePrint(object sender, CancelEventArgs e)
        {
            if (GetCurrentRow() is DailyClosingInventoryDto data)
            {
                bool any = false;
                foreach (var payment in data.Payments)
                {
                    any = true;
                    break;
                }

                e.Cancel = data?.Payments == null || !any;
            }
        }

        private void ReportFooter2_BeforePrint(object sender, CancelEventArgs e)
        {
            if (GetCurrentRow() is not DailyClosingInventoryDto data)
            {
                e.Cancel = true;
                return;
            }

            var isAllEmpty = string.IsNullOrWhiteSpace(data.Expense.ToString()) &&
                             string.IsNullOrWhiteSpace(data.ExpenseRiel.ToString()) &&
                             string.IsNullOrWhiteSpace(data.ExchangeRate.ToString()) &&
                             string.IsNullOrWhiteSpace(data.Vat.ToString()) &&
                             string.IsNullOrWhiteSpace(data.CashChange);

            e.Cancel = isAllEmpty;
        }
        private void CancelIfPropertyEmpty(object sender, CancelEventArgs e, Func<DailyClosingInventoryDto, string> propertySelector)
        {
            if (GetCurrentRow() is not DailyClosingInventoryDto data || string.IsNullOrWhiteSpace(propertySelector(data)))
            {
                e.Cancel = true;
            }
        }
        private void xrLabel16_BeforePrint(object sender, CancelEventArgs e)
        {
            CancelIfPropertyEmpty(sender, e, dto => dto.TotalPrice);
        }

        private void xrLabel15_BeforePrint(object sender, CancelEventArgs e)
        {
            CancelIfPropertyEmpty(sender, e, dto => dto.TotalPrice);
        }

        #endregion
        #region Report 80

        private void ReportHeader1_BeforePrint_80(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosing80Dto;
            e.Cancel = data?.Payments == null || !data.Payments.Any();
        }

        private void Detail2_BeforePrint_80(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosing80Dto;
            e.Cancel = data?.Payments == null || !data.Payments.Any();
        }

        private void ReportFooter2_BeforePrint_80(object sender, CancelEventArgs e)
        {
            if (GetCurrentRow() is not DailyClosing80Dto data)
            {
                e.Cancel = true;
                return;
            }

            var isAllEmpty = string.IsNullOrWhiteSpace(data.Expense?.ToString()) &&
                             string.IsNullOrWhiteSpace(data.ExpenseRiel?.ToString()) &&
                             string.IsNullOrWhiteSpace(data.ExchangeRate.ToString()) &&
                             string.IsNullOrWhiteSpace(data.Vat.ToString()) &&
                             string.IsNullOrWhiteSpace(data.CashChange.ToString());

            e.Cancel = isAllEmpty;
        }
        private void CancelIfPropertyEmpty_80(object sender, CancelEventArgs e, Func<DailyClosing80Dto, string> propertySelector)
        {
            var data = GetCurrentRow() as DailyClosing80Dto;

            if (data == null || string.IsNullOrWhiteSpace(propertySelector(data)))
            {
                e.Cancel = true;
            }
        }
        private void xrLabel16_BeforePrint_80(object sender, CancelEventArgs e)
        {
            CancelIfPropertyEmpty_80(sender, e, dto => dto.TotalPrice);
        }

        private void xrLabel15_BeforePrint_80(object sender, CancelEventArgs e)
        {
            CancelIfPropertyEmpty_80(sender, e, dto => dto.TotalPrice);
        }

        #endregion
        #region By Category

        private void ReportHeader1_BeforePrint_ByCategory(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosingInventoryByCategoryDto;
            e.Cancel = data?.Payments == null || !data.Payments.Any();
        }

        private void Detail2_BeforePrint_ByCategory(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosingInventoryByCategoryDto;
            e.Cancel = data?.Payments == null || !data.Payments.Any();
        }

        private void ReportFooter2_BeforePrint_ByCategory(object sender, CancelEventArgs e)
        {
            var data = GetCurrentRow() as DailyClosingInventoryByCategoryDto;

            if (data == null)
            {
                e.Cancel = true;
                return;
            }

            var isAllEmpty = string.IsNullOrWhiteSpace(data.Expense.ToString()) &&
                             string.IsNullOrWhiteSpace(data.ExpenseRiel.ToString()) &&
                             string.IsNullOrWhiteSpace(data.ExchangeRate.ToString()) &&
                             string.IsNullOrWhiteSpace(data.Vat.ToString()) &&
                             string.IsNullOrWhiteSpace(data.CashChange);

            e.Cancel = isAllEmpty;
        }
        private void CancelIfPropertyEmpty_ByCategory(object sender, CancelEventArgs e, Func<DailyClosingInventoryByCategoryDto, string> propertySelector)
        {
            var data = GetCurrentRow() as DailyClosingInventoryByCategoryDto;

            if (data == null || string.IsNullOrWhiteSpace(propertySelector(data)))
            {
                e.Cancel = true;
            }
        }
        private void xrLabel16_BeforePrint_ByCategory(object sender, CancelEventArgs e)
        {
            CancelIfPropertyEmpty_ByCategory(sender, e, dto => dto.TotalPrice);
        }

        private void xrLabel15_BeforePrint_ByCategory(object sender, CancelEventArgs e)
        {
            CancelIfPropertyEmpty_ByCategory(sender, e, dto => dto.TotalPrice);
        }

        #endregion
    }
}
