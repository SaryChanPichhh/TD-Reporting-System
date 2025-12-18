using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BC.ACCOUNTING.REPORT.Helper.Enums
{
    public enum Expiration
    {
        [Description("ទំនិញផុតកំណត់")] Expired = 1,
        [Description("ទំនិញជិតផុតកំណត់")] NearlyExpired = 2,

    }
}
