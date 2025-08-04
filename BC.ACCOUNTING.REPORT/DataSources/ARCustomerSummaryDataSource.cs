using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ARCustomerSummaryDataSource
    {
        [DisplayName("កូដអតិថិជន")] public string CustomerCode { get; set; }
        [DisplayName("ឈ្មោះអតិថិជន")] public string CustomerName { get; set; }
        [DisplayName("ទឹកប្រាក់អនុម័ត")] public string Approved { get; set; }
        [DisplayName("ទឹកប្រាក់កំពុងរង់ចាំ")] public string Pending { get; set; }
        [DisplayName("ទឹកប្រាក់បដិសេធ")] public string Rejected { get; set; }
        [DisplayName("បង្កាន់ដៃសរុប")] public string Receipts { get; set; }
    }
}
