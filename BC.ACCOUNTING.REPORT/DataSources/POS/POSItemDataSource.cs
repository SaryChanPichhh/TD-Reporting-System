namespace BC.ACCOUNTING.REPORT.DataSources.POS
{
    public class POSItemDataSource
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string? Image { get; set; }
        public byte[]? ImageByte  { get; set; }  
    }
}
