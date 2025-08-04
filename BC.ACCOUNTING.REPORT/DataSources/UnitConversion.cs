using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    [DisplayName("ខ្នាតទំនិញ")]
    public class UnitConversion
    {
        [DisplayName("ឈ្មោះខ្នាត")] public string CONV_T_DESC { get; set; }
        [DisplayName("ឈ្មោះខ្នាតខ្មែរ")] public string CONV_T__DESCKH { get; set; }
        [DisplayName("ដើមគ្រា")] public int PHYSICAL { get; set; }
        [DisplayName("លក់")] public int ON_ORDER { get; set; }
        [DisplayName("ក្នុងស្តុក")] public int TOTAL { get; set; }
       
    }
}
