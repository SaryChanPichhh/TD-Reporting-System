using Dapper;
using System.Data;
using System.Reflection;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Helper
{
    public static class AppExtension
    {
        public static DataTable ConvertToDataTable<T>(IEnumerable<T> list)
        {
            var dataTable = new DataTable();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                var columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, columnType);
            }

            foreach (var item in list)
            {
                var row = dataTable.NewRow();
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(item, null);
                    row[prop.Name] = value ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        //public static void RegisterColumnMapping<T>()
        //{
        //    SqlMapper.SetTypeMap(typeof(T),
        //        new CustomPropertyTypeMap(
        //            typeof(T),
        //            (type, columnName) =>
        //                type.GetProperties().FirstOrDefault(
        //                    prop => prop.Name.Equals(columnName.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)
        //                )
        //        )
        //    );
        //}
        public static void RegisterColumnMapping<T>()
        {
            SqlMapper.SetTypeMap(typeof(T),
                new CustomPropertyTypeMap(
                    typeof(T),
                    (type, columnName) =>
                    {
                        // Normalize the column name: remove spaces, replace '-' with '_'
                        string normalizedColumnName = columnName.Replace(" ", "").Replace("-", "_");

                        return type.GetProperties()
                            .FirstOrDefault(prop =>
                                prop.Name.Equals(normalizedColumnName, StringComparison.OrdinalIgnoreCase)
                            );
                    }
                )
            );
        }


    }
}
