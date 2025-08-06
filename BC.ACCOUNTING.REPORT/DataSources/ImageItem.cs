using System;
using System.IO;
using DevExpress.Office.Drawing;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ImageItem
    {
        public string ImageData { get; set; }

        //public byte[] ImageData
        //{
        //    get
        //    {
        //        return File.Exists(ImagePath)
        //            ? File.ReadAllBytes(ImagePath)
        //            : Array.Empty<byte>(); // or throw new FileNotFoundException()
        //    }
        //}
    }

}
