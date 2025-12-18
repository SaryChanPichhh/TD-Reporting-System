using BC.ACCOUNTING.REPORT.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using DevExpress.Xpo;
using BC.ACCOUNTING.REPORT.Helper.Enums;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class InventoryExpiredDataSource
    {
        public string? Category { get; set; }
        public string? Location { get; set; }
        public string? ItemDescKh { get; set; }
        public string UnitStock { get; set; }
        public string ItemCode { get; set; }
        public string? ItemDesc { get; set; }
        public string? ItemImage { get; set; }
        public byte[]? ImageByte { get; set; }
        public int  Quantity { get; set; }
        public DateTime ExpiredDate { get; set; }
        [Browsable(false)]
        [Nullable(true)]
        public TimeSpan TimeSpan => ExpiredDate-DateTime.Now ;
        public Expiration Status => TimeSpan.Hours > 0 ?Expiration.NearlyExpired:Expiration.Expired;
        public string? ExpiredDescription => Status.GetEnumDescription();
    }
}
