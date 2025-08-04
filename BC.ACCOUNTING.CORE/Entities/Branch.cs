namespace BC.ACCOUNTING.CORE.Entities
{
    public class Branch:AuditModel
    {
        public string? DbCode { get; set; }
        public string? DbName { get; set; }
        public string? DateDefault { get; set; }
        public string? DateFormat { get; set; }
        public string? SaDecimal { get; set; }
        public string? SbDecimal { get; set; }
        public string? DecSep { get; set; }
        public string? ThoSep { get; set; }
        public string? DbStat { get; set; }
       
    }
}
