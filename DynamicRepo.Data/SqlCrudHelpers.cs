using DynamicRepo.Data;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;

namespace DynamicRepo.Data
{
    public abstract class SqlCrudHelpers
    {
     
        static JObject DataTableToJsonObject(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return new JObject(rows);
        }
    }
}