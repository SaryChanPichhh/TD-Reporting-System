using DevExpress.Xpo;

namespace BC.ACCOUNTING.REPORT.DataSources.RESTAURANT
{
    public class RESItemDataSource
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        [Nullable(true)]
        public string? Image { get; set; }
        [Nullable(true)]
        public byte[]? ImageByte { get; set; }
        
    }
}
