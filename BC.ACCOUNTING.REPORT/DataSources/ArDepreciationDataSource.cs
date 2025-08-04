using System;
using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ArDepreciationDataSource
    {
        [DisplayName("ថ្ងៃត្រូវទូទាត់")]  public DateTime? DueDate { get; set; }
        [DisplayName("ទឹកប្រាក់")] public string? TransValue { get; set; }
        [DisplayName("ចំនួនទូទាត់")] public string? Amount { get; set; }
        [DisplayName("នៅសល់")] public string? Balance { get; set; }
        [DisplayName("ចំណាំ")]  public string? RefNote { get; set; }
      
        
    }
}
