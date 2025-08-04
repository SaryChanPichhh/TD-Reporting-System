namespace BC.ACCOUNTING.REPORT.DataSources
{
    public class ReportDividedInvoiceToDeliveriesDataSource
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Store { get; set; }
        public string TransactionCode { get; set; }
        public int OldInvoice { get; set; }
        public int NewInvoice { get; set; }
        public int ChangeInvoice { get; set; }
        public double Value { get; set; }

        //public class Shipping
        //{
        //    public string DeliveryId { get; set; }
        //    public int UserId { get; set; }
        //    public string DbName { get; set; }
        //    public string DbCode { get; set; }
        //    public string InvRef { get; set; }
        //    public string AreaId { get; set; }
        //    public string To { get; set; }
        //}
    }
}
