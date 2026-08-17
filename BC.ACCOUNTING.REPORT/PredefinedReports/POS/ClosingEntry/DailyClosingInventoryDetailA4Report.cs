using BC.ACCOUNTING.REPORT.DataSources.POS;
using System.ComponentModel;
using System.Drawing;
using static System.Double;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.ClosingEntry
{
    public partial class DailyClosingInventoryDetailA4Report : DevExpress.XtraReports.UI.XtraReport
    {
        private List<PaymentMethodDataSource> Payments { get; set; } = new();
        private int _itemRowIndex = 0;
        public DailyClosingInventoryDetailA4Report()
        {
            InitializeComponent();
        }

        public DailyClosingInventoryDetailA4Report(DailyClosingInventoryDetailDto inventoryDto, string reportName)
        {

            if (inventoryDto == null) return;

            decimal Parse(string? v)
            {
                if (string.IsNullOrWhiteSpace(v)) return 0;
                var cleaned = new string(v.Where(c => char.IsDigit(c) || c == '.' || c == '-').ToArray());
                return decimal.TryParse(cleaned, out var r) ? r : 0;
            }

            var globalPayments = inventoryDto.DailyClosings
                .SelectMany(x => x.Payments ?? new List<ClosingDetailPaymentMethodDataSource>())
                .GroupBy(p => p.PaymentType)
                .Select(pg =>
                {
                    var totalValue = pg.Sum(p => Parse(p.TotalRecieved));
                    var isRiel = pg.Key?.ToUpper().Contains("KHR") == true || pg.Key?.Contains("៛") == true;

                    return new ClosingDetailPaymentMethodDataSource
                    {
                        PaymentType = pg.Key,
                        TotalRecieved = totalValue.ToString(),
                        CurrencySymbol = isRiel ? "៛" : "$"
                    };
                }).ToList();

            inventoryDto.DailyClosings = inventoryDto.DailyClosings
                .GroupBy(dc => new { dc.Seller, dc.Dates })
                .Select(group =>
                {
                    var items = group.SelectMany(x => x.Items ?? new List<ItemDataSource>())
                        .GroupBy(i => new { i.ItemCode, i.Price })
                        .Select(ig =>
                        {
                            var qty = ig.Sum(x => x.Qty);
                            var unitPriceStr = ig.Key.Price;
                            decimal.TryParse(unitPriceStr.ToString(), out var unitPrice);

                            var discount = ig.Sum(x => x.DiscountPrice);

                            return new ItemDataSource
                            {
                                ItemCode = ig.Key.ItemCode,
                                ItemDesc = ig.First().ItemDesc,
                                Qty = qty,
                                Price = unitPriceStr,
                                DiscountPrice = discount,
                                // 2. Ensure qty and unitPrice are also decimals so the math is consistent
                                Total = (qty * unitPrice - discount)
                            };
                        }).ToList();

                    return new DailyClosingDetailDataSource
                    {
                        Seller = group.Key.Seller,
                        Dates = group.Key.Dates,
                        Items = items,
                        Payments = globalPayments,
                    };
                }).ToList();

            this.LoadLayoutFromXml(reportName);

            if (Parameters["SubDecimalPrecision"] != null)
                Parameters["SubDecimalPrecision"].Value = inventoryDto.SubDecimalPrecision.GetEnumDescription();

            if (Parameters["DecimalPrecision"] != null)
                Parameters["DecimalPrecision"].Value = inventoryDto.DecimalPrecision.GetEnumDescription();

            if (Parameters["DiscountInvoice"] != null)
                Parameters["DiscountInvoice"].Value = inventoryDto.DiscountInvoice;

            this.objectDataSource1.DataSource = inventoryDto;
            this.BeforePrint += (s, e) =>
            {
                if (this.FindControl("GroupHeader3", true) is Band dateGroupHeader)
                {
                    dateGroupHeader.BeforePrint += (sender, args) => { _itemRowIndex = 0; };
                }

                if (this.FindControl("xrTableCell12", true) is XRTableCell rowCell)
                {
                    rowCell.BeforePrint += (sender, args) =>
                    {
                        _itemRowIndex++;
                        XRTableCell cell = (XRTableCell)sender;
                        cell.Text = _itemRowIndex.ToString();

                        Color rowColor = (_itemRowIndex % 2 == 0) ? Color.WhiteSmoke : Color.White;

                        if (cell.Row is XRTableRow row)
                        {
                            foreach (XRTableCell c in row.Cells)
                            {
                                c.BackColor = rowColor;
                            }
                        }
                    };
                }

                if (this.FindControl("ReportHeader1", true) is Band rh) rh.BeforePrint += TogglePayments;
                if (this.FindControl("Detail2", true) is Band d2) d2.BeforePrint += TogglePayments;
            };
        }

        private void TogglePayments(object? s, CancelEventArgs e)
        {
            var d = GetCurrentRow() as DailyClosingDetailDataSource;
            e.Cancel = d?.Payments == null || !d.Payments.Any();
        }

    }
}