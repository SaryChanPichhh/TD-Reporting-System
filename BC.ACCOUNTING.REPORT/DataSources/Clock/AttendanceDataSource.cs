namespace BC.ACCOUNTING.REPORT.DataSources.Clock
{
    public class AttendanceDataSource
    {
        public string Position { get; set; } = string.Empty;
        public string EmpCode { get; set; } = string.Empty;
        public string EmpName { get; set; } = string.Empty;
        public int Attendances { get; set; } = 0;
        public int Leaves { get; set; } = 0;
        public int Absences { get; set; } = 0;
        public int Lates { get; set; } = 0;
        public int Tardies { get; set; } = 0;
        public int OverTimes { get; set; } = 0;
        public int TotalHours { get; set; } = 0;
        public int Holidays { get; set; } = 0;
        public List<AttendanceData> AbsenceDates { get; set; } = [];

    }

    public class AttendanceData
    {
        public DateTime Date { get; set; }
        public int Desc { get; set; } = 0;
    }

    public class AttendancePivotDataSource
    {
        public string Position { get; set; } = string.Empty;
        public string EmpCode { get; set; } = string.Empty;
        public string EmpName { get; set; } = string.Empty;
        public int Attendances { get; set; } = 0;
        public int Leaves { get; set; } = 0;
        public int Absences { get; set; } = 0;
        public int Lates { get; set; } = 0;
        public int Tardies { get; set; } = 0;
        public int OverTimes { get; set; } = 0;
        public int TotalHours { get; set; } = 0;
        public int Holidays { get; set; } = 0;
        public DateTime Date { get; set; }
        public string Desc { get; set; } = string.Empty;
    }
}
