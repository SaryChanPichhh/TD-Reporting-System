
using BC.ACCOUNTING.CORE.Entities;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport
    .Sale_Listing.ByDate.BySeller.Detail.M01
{
    public partial class M01SaleListingDetailBySellerReport : XtraReport
    {
        private int recordIndex = 0;

        public M01SaleListingDetailBySellerReport()
        {
            InitializeComponent();
        }

        public M01SaleListingDetailBySellerReport(
            List<SaleListingModel> ls,
            string reportName,
            SaleListingDto dto)
        {
            LoadLayoutFromXml(reportName);

            var data = ls
                .GroupBy(x => new
                {
                    x.DetailItemCode,
                    x.Value_3,
                })
                .Select(g =>
                {
                    var first = g.First();

                    return new SaleListingModel
                    {
                        CustomerWebPage = first.CustomerWebPage,
                        HeaderAnalysisM9Description = first.HeaderAnalysisM9Description,
                        HeaderAnalysisM8Description = first.HeaderAnalysisM8Description,
                        HeaderAnalysisM6Description = first.HeaderAnalysisM6Description,
                        HeaderAnalysisM0Description = first.HeaderAnalysisM0Description,
                        HeaderAnalysisM9 = first.HeaderAnalysisM9,
                        DetailItemCode = first.DetailItemCode,
                        DetailDescription = first.DetailDescription,
                        TotalValue = first.TotalValue,
                        Value_3 = first.Value_3,
                        Value_13 = first.Value_13,
                        Value_1 = g.Sum(x => x.Value_1),

                        HeaderTransactionRef = first.HeaderTransactionRef,
                        HeaderTransactionDate = first.HeaderTransactionDate,
                        CustomerCode = first.CustomerCode,
                        CustomerName = first.CustomerName,

                        SubItems = g.SelectMany(x => x.SubItems).ToList()
                    };
                })
                .ToList();

            objectDataSource1.DataSource = data;
            DataSource = objectDataSource1;

            SetReportParameters(dto);

            prm_EndDate.Value = string.IsNullOrWhiteSpace(dto.Date2) ? dto.Prd2 : dto.Date2;
            prm_StartDate.Value = string.IsNullOrWhiteSpace(dto.Date1) ? dto.Prd1 : dto.Date1;
            if (prm_StartDate?.Value != null && string.IsNullOrEmpty(dto.Date1) && string.IsNullOrEmpty(dto.Prd1))
            {
                if (xrLabel13 is not null && xrLabel8 is not null)
                    xrLabel8.Visible = xrLabel13.Visible = false;
            }

            if (prm_EndDate?.Value != null && string.IsNullOrEmpty(dto.Date2) && string.IsNullOrEmpty(dto.Prd2))
            {
                if (xrLabel13 is not null && xrLabel14 is not null)
                    xrLabel14.Visible = xrLabel13.Visible = false;
            }

            prm_CompanyName.Value = dto.CompanyName;
            try
            {
                if (xrTableCell2 != null)
                {
                    if (GroupHeader1 != null)
                    {   
                        GroupHeader1.BeforePrint -= GroupHeader1_BeforePrint;
                        GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
                    }
                    if (GroupHeader2 != null)
                    {
                        GroupHeader2.BeforePrint -= GroupHeader2_BeforePrint;
                        GroupHeader2.BeforePrint += GroupHeader2_BeforePrint;
                    }
                    if (GroupHeader3 != null)
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
            }

            AggregateSubItems(data);
            HookEvents();
        }

        private void AggregateSubItems(List<SaleListingModel> ls)
        {
            if (ls == null) return;

            foreach (var sale in ls)
            {
                if (sale.SubItems == null || sale.SubItems.Count == 0)
                    continue;

                sale.SubItems = sale.SubItems
                    .GroupBy(x => new
                    {
                        x.ItemCode,
                        x.ItemDesc,
                        x.UnitConvCode,
                        x.UnitConv,
                    })
                    .Select(g => new MOSubItemDataSource
                    {
                        ItemCode = g.Key.ItemCode,
                        ItemDesc = g.Key.ItemDesc,
                        UnitConvCode = g.Key.UnitConvCode,
                        UnitConv = g.Key.UnitConv,
                        ConvFromDesc = g.First().ConvFromDesc ?? string.Empty,
                        HeaderTransactionRef = g.First().HeaderTransactionRef,
                        ItemCost = g.First().ItemCost,
                        Qty = g.Sum(x => x.Qty)

                    })
                    .ToList();

            }
        }

        private void SetReportParameters(SaleListingDto dto)
        {
            if (Parameters["DecimalPrecision"] != null)
                DecimalPrecision.Value = dto.DecimalPrecision.GetEnumDescription();

            if (Parameters["SubDecimalPrecision"] != null)
                SubDecimalPrecision.Value = dto.SubDecimalPrecision.GetEnumDescription();

            if (Parameters["CurrencySymbol"] != null)
                CurrencySymbol.Value = string.IsNullOrEmpty(dto.CurrencySymbol) ? "$" : dto.CurrencySymbol;

            if (Parameters["SubCurrencySymbol"] != null)
                SubCurrencySymbol.Value = string.IsNullOrEmpty(dto.SubCurrencySymbol) ? "៛" : dto.SubCurrencySymbol;
        }


        private void HookEvents()
        {
            if (Detail == null) return;

            if (GroupHeader2 != null)
            {
                GroupHeader2.BeforePrint -= GroupHeader2_BeforePrint;
                GroupHeader2.BeforePrint += GroupHeader2_BeforePrint;
            }

            if (GroupHeader1 != null)
            {
                GroupHeader1.BeforePrint -= GroupHeader1_BeforePrint;
                GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            }
        }


        private int _recordNo = 0; 

        private void GroupHeader2_BeforePrint(object sender, CancelEventArgs e)
        {
            _recordNo = 0;
        }

        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            _recordNo++;
            if (xrTableCell2 != null)
            {
                xrTableCell2.Text = _recordNo.ToString();
            }

            if (xrTable2 != null)
                xrTable2.BackColor = _recordNo % 2 == 0 ? Color.WhiteSmoke : Color.White;
        }
    }
}

