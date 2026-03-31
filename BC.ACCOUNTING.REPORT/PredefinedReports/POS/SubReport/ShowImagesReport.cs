using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BC.ACCOUNTING.REPORT.PredefinedReports.POS.SubReport
{
    public partial class ShowImagesReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ShowImagesReport()
        {
            InitializeComponent();
            xrPictureBox1.ExpressionBindings.Add(
                new ExpressionBinding("BeforePrint", "ImageUrl", "[ImageUrl]")
            );
            xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Cover;
        }

    }
}
