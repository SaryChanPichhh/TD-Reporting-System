using System;
using DevExpress.XtraReports.Native;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class MBCustomerDataSource
    {
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MarketName { get; set; }
        public string Branch { get; set; }
        public string BranchCode { get; set; }
        public decimal TotalOrderAmount { get; set; } = 0;
        public decimal TotalDebtAmount { get; set; } = 0;
        public DateTime PaymentDueDate { get; set; } = DateTime.Today;

        // NEW: For DevExpress UI concatenation
        public string BranchFullName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(BranchCode) && !string.IsNullOrWhiteSpace(Branch))
                    return $"{BranchCode} - {Branch}";

                return BranchCode;
            }
        }
    }
}