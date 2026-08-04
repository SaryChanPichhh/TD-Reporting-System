using System.Globalization;
using System.Text.Json;

namespace BC.ACCOUNTING.REPORT.Helper
{
    public static class Converting
    {
        public static string ToStringSafe(this object? value)
        {
            if (value == null) return "";

            if (value is JsonElement json)
            {
                return json.ValueKind switch
                {
                    JsonValueKind.String => json.GetString() ?? "",
                    JsonValueKind.Number => json.ToString(),
                    _ => ""
                };
            }

            return value.ToString() ?? "";
        }

        public static int ToIntSafe(this object? value)
        {
            if (value == null) return 0;

            if (value is JsonElement json)
            {
                if (json.ValueKind == JsonValueKind.Number) return json.GetInt32();

                if (json.ValueKind == JsonValueKind.String &&
                    int.TryParse(json.GetString(), out var result))
                    return result;

                return 0;
            }

            return int.TryParse(value.ToString(), out var normalResult)
                ? normalResult
                : 0;
        }

        public static decimal ToDecimalSafe(this object? value)
        {
            if (value == null) return 0m;

            if (value is JsonElement json)
            {
                if (json.ValueKind == JsonValueKind.Number) return json.GetDecimal();

                if (json.ValueKind == JsonValueKind.String &&
                    decimal.TryParse(json.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                    return result;
                return 0m;
            }

            return decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var normalResult)
                ? normalResult
                : 0m;
        }
    }
}
