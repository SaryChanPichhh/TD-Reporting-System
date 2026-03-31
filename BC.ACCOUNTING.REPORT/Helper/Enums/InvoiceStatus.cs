using System.ComponentModel;

namespace BC.ACCOUNTING.REPORT.Helper.Enums
{
    public enum InvoiceStatus
    {
        [Description("មិនទាន់ទូទាត់ - UNPAID")]
        NOT_PAID =0,
        [Description("ទូទាត់មិនគ្រប់ - Underpaid")]
        INSUFFICIENT_PAID = 1,
        [Description("ទូទាត់រួចរាល់ - Paid")]
        PAID =2,
    }
}
