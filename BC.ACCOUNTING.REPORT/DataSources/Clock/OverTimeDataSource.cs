namespace BC.ACCOUNTING.REPORT.DataSources.Clock
{
    public class OverTimeDataSource
    {
        public string EmpCode { get; set; } = string.Empty;
        public string EmpName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public List<OverTimeData> Data { get; set; } = [];
        public List<DateTime> Dates { get; set; } = [];
    }

    public class OverTimeData
    {
        public DateTime Date { get; set; }
        public double OverTime { get; set; }
    }   
    public class OverTimePivotDataSource
    {
        public string EmpCode { get; set; } = string.Empty;
        public string EmpName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public double OverTime { get; set; } = 1.0;
    }
}
