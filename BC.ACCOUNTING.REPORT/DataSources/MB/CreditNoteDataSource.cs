using System;

namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class CreditNoteDataSource : ItemDataSource
    {

    }
    public class CreditNoteFlattenDataSource{
       public string ItemCode { get; set; } 
       public string ItemDesc { get; set; }
       public string? ItemImage { get; set; } 
       public string UnitStock { get; set; }
       public int Qty { get; set; }
       public decimal Price { get; set; }
       public decimal Total { get; set; }
    }
}
