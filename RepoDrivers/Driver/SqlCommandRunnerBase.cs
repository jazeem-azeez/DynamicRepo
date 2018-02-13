using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;
using System.Collections.Generic;
using System.Data;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public abstract class SqlCommandRunnerBase
    {
       public JObject DataTableToJsonObject(DataTable dt)
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