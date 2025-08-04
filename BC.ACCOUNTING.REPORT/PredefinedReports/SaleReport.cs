using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraReports.UI;

namespace BC.ACCOUNTING.REPORT.PredefinedReports;

public partial class SaleReport : XtraReport
{
    public SaleReport(List<SaleDto> data, string startDate, string endDate)
    {

       
        // Assign data source
        this.DataSource = data;
        this.DataMember = "";

        // Report Title
        XRLabel titleLabel = new XRLabel
        {
            Text = "Product Sales Report",
            Font = new Font("Arial", 16, FontStyle.Bold),
            BoundsF = new RectangleF(0, 0, 600, 30),
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        };
        ReportHeaderBand header = new ReportHeaderBand { HeightF = 40 };
        header.Controls.Add(titleLabel);
        Bands.Add(header);

        // Show filter dates
        XRLabel dateRangeLabel = new XRLabel
        {
            Text = $"From: {startDate}  To: {endDate}",
            Font = new Font("Arial", 10, FontStyle.Italic),
            BoundsF = new RectangleF(0, 35, 600, 20),
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        };
        header.Controls.Add(dateRangeLabel);

        // Group by ProductCode
        GroupHeaderBand groupHeader = new GroupHeaderBand { HeightF = 25 };
        GroupField groupField = new GroupField("ProductCode");
        groupHeader.GroupFields.Add(groupField);

        XRLabel productCodeLabel = new XRLabel
        {
            ExpressionBindings = { new ExpressionBinding("BeforePrint", "Text", "[ProductCode] + ' - ' + [ProductName]") },
            Font = new Font("Arial", 10, FontStyle.Bold),
            BoundsF = new RectangleF(0, 0, 600, 25)
        };
        groupHeader.Controls.Add(productCodeLabel);
        Bands.Add(groupHeader);

        // Detail Table
        DetailBand detail = new DetailBand { HeightF = 25 };
        Bands.Add(detail);

        XRTable table = new XRTable { BoundsF = new RectangleF(0, 0, 600, 25) };
        XRTableRow row = new XRTableRow();
        row.Cells.Add(CreateCell("[SaleDate]", 100));
        row.Cells.Add(CreateCell("[Quantity]", 100));
        row.Cells.Add(CreateCell("[UnitPrice]", 100));
        row.Cells.Add(CreateCell("[Total]", 100));
        table.Rows.Add(row);
        detail.Controls.Add(table);

        // Group Footer (Subtotal)
        GroupFooterBand groupFooter = new GroupFooterBand { HeightF = 25 };
        XRLabel subtotalLabel = new XRLabel
        {
            Text = "Subtotal:",
            BoundsF = new RectangleF(200, 0, 100, 25),
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        XRLabel subtotalAmount = new XRLabel
        {
            ExpressionBindings = { new ExpressionBinding("BeforePrint", "Text", "Sum([Total])") },
            BoundsF = new RectangleF(300, 0, 100, 25),
            Font = new Font("Arial", 10, FontStyle.Bold),
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        };
        subtotalAmount.Summary = new XRSummary(SummaryRunning.Group, SummaryFunc.Sum, "{0:c2}");
        groupFooter.Controls.Add(subtotalLabel);
        groupFooter.Controls.Add(subtotalAmount);
        Bands.Add(groupFooter);

        // Report Footer (Grand Total)
        ReportFooterBand footer = new ReportFooterBand { HeightF = 30 };
        XRLabel totalLabel = new XRLabel
        {
            Text = "Grand Total:",
            BoundsF = new RectangleF(200, 0, 100, 25),
            Font = new Font("Arial", 11, FontStyle.Bold)
        };
        XRLabel totalAmount = new XRLabel
        {
            ExpressionBindings = { new ExpressionBinding("BeforePrint", "Text", "Sum([Total])") },
            BoundsF = new RectangleF(300, 0, 100, 25),
            Font = new Font("Arial", 11, FontStyle.Bold),
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        };
        totalAmount.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.Sum, "{0:c2}");
        footer.Controls.Add(totalLabel);
        footer.Controls.Add(totalAmount);
        Bands.Add(footer);
    }

    public SaleReport()
    {
        InitializeComponent();
    }
    private XRTableCell CreateCell(string expression, float width)
    {
        return new XRTableCell
        {
            ExpressionBindings = { new ExpressionBinding("BeforePrint", "Text", expression) },
            WidthF = width,
            Font = new Font("Arial", 9),
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        };
    }
}

public class SaleDto
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total => Quantity * UnitPrice;
    public DateTime SaleDate { get; set; }
}