using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BC.ACCOUNTING.REPORT.DataSources.RESTAURANT
{
    public class RESSaleReceiptDataSource
    {
        public string ItemDesc { get; set; }
        public string UnitPrice { get; set; }
        public int Qty { get; set; }
        public string Discount { get; set; }
        public string Total { get; set; }

        [JsonPropertyName("AddOns")]
        public List<string> AddOns { get; set; } = new();

        public List<AddOnDataSource>? AddOnDataSource { get; set; }

        public RESSaleReceiptDataSource() { }

        // Optional constructor
        public RESSaleReceiptDataSource(List<string> addOns)
        {
            AddOns = addOns ?? new List<string>();
        }

        public List<string> GetAddOns()
        {
            if (AddOns?.Any() == true)
                return AddOns;

            if (AddOnDataSource?.Any() == true)
                return AddOnDataSource.Select(a => a.Description).ToList();

            return new List<string>();
        }

        [JsonIgnore]
        public string AddOnsDisplay => string.Join(", ", GetAddOns().Where(a => !string.IsNullOrWhiteSpace(a)));
    }
    public class AddOnDataSource
    {
        public string Description { get; set; }

    }

}
