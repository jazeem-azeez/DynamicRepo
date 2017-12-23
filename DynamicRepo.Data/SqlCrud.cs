using DynamicRepo.Data;
using System.Collections.Generic;
using System.Data;

namespace DynamicRepo.Business
{
    public class SqlCrud
    {
        public object Test()
        {
            PostGresSqlQueryRunner postGresSqlQueryRunner = new PostGresSqlQueryRunner();
            var dt = postGresSqlQueryRunner.RunSQlExecuteReader("select * from \"TestTable\"");
            return DataTableToJsonObject(dt);
        }

        static object DataTableToJsonObject(DataTable dt)
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
            return rows;
        }
    }
}