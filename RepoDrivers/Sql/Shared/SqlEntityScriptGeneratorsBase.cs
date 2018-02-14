using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RepoDrivers.Sql.Shared
{
    public abstract class SqlEntityScriptGeneratorsBase
    {
        public JTokenType CheckforStringSubTypes(JTokenType value, string valueString)
        {
            var guidOut = Guid.Empty;
            if (value == JTokenType.String && Guid.TryParse(valueString, out guidOut))
                return JTokenType.Guid;
            return value;
        }

        public string CreateAndInsert(JObject jObject, string entityName)
        {
            List<string> columns;
            Dictionary<string, object> valuesToInsert;
            Dictionary<string, JTokenType> typesLookUp;

            ExtractJsonObjectData(jObject, out columns, out valuesToInsert, out typesLookUp);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Create table IF NOT EXISTS {entityName} ({string.Join(", ", columns)});");
            string columnsName = string.Empty;
            string values = GetValuesAndColumns(typesLookUp, valuesToInsert, out columnsName);
            stringBuilder.AppendLine($" Insert into {entityName}  ({columnsName}) values ({values});");

            return stringBuilder.ToString();
        }

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

        public string Delete(string entityName, string filter)
        {
            return $"delete from {entityName} where {filter} ";
        }

        public void ExtractJsonObjectData(JObject jObject, out List<string> columns, out Dictionary<string, object> valuesToInsert, out Dictionary<string, JTokenType> typesLookUp)
        {
            columns = new List<string>();
            valuesToInsert = new Dictionary<string, object>();
            typesLookUp = new Dictionary<string, JTokenType>();
            foreach (var item in jObject.Properties())
            {
                if (item.Value is JValue)
                {
                    var value = ((JValue)item.Value);
                    Console.WriteLine($"{item.Name}: { value.Type},{ value.Value}");
                    valuesToInsert.Add(item.Name, value.Value);
                    typesLookUp.Add(item.Name, value.Type);
                    columns.Add($"{item.Name}  {JTokenTypeToSqlType(value.Type, value.Value.ToString())} ");
                }
                else if (item.Value is JProperty)
                {
                    var value = ((JProperty)item.Value);
                    valuesToInsert.Add(item.Name, value.Value.ToString());
                    columns.Add($"{item.Name}  {JTokenTypeToSqlType(value.Type, value.Value.ToString())} ");
                    typesLookUp.Add(item.Name, value.Type);

                    Console.WriteLine($" {item.Name}: { value.Type},{ value.Value}");
                }
                else if (item.Value is JArray)
                {
                    var value = ((JArray)item.Value);
                    valuesToInsert.Add(item.Name, value.ToString());
                    columns.Add($"{item.Name}  {JTokenTypeToSqlType(value.Type)} ");
                    typesLookUp.Add(item.Name, value.Type);

                    Console.WriteLine($" {item.Name}: { value.Type},{ value}");
                }
                else if (item.Value is JObject)
                {
                    var value = ((JObject)item.Value);
                    valuesToInsert.Add(item.Name, value.ToString());
                    columns.Add($"{item.Name}  {JTokenTypeToSqlType(value.Type)} ");
                    typesLookUp.Add(item.Name, value.Type);
                    Console.WriteLine($"{item.Name}: { value.Type},{ value}");
                }
                else
                {
                    Console.WriteLine("Unknown Type Encountered ");
                }
            }
        }

        public string GetValuesAndColumns(Dictionary<string, JTokenType> typesLookUp, Dictionary<string, object> valuesToInsert, out string columnsNames)
        {
            List<string> valuesCollection = new List<string>();
            List<string> columnsCollection = new List<string>();
            foreach (var item in typesLookUp)
            {
                var value = string.Empty;
                columnsCollection.Add(item.Key);
                value = ValuesCasting(valuesToInsert, item);
                valuesCollection.Add(value);
            }
            columnsNames = string.Join(", ", columnsCollection);
            return string.Join(", ", valuesCollection);
        }

        public string JTokenTypeToSqlType(JTokenType tokenType, string value = null)
        {
            string result = string.Empty;
            var jTokenTypetemp = CheckforStringSubTypes(tokenType, value);
            switch (jTokenTypetemp)
            {
                case JTokenType.Integer: result = "NUMERIC(12,4)"; break;
                case JTokenType.Guid: result = "uuid"; break;
                case JTokenType.String: result = "varchar(1024)"; break;
                case JTokenType.Date: result = "Date"; break;
                case JTokenType.Float: result = "NUMERIC(12,4)"; break;
                case JTokenType.Uri: result = "varchar(1024)"; break;
                case JTokenType.Object: result = "varchar(2048)"; break;
                case JTokenType.Array: result = "varchar(2048)"; break;
                case JTokenType.Property: result = "varchar(2048)"; break;
                case JTokenType.Bytes: result = "VARBINARY(2048)"; break;
                case JTokenType.Boolean: result = "boolean"; break;
            }
            return result;
        }

        public string Retrive(string entityName, string filter, int offset, int limit)
        {
            filter = string.IsNullOrEmpty(filter) ? string.Empty : $"where { filter}";
            return $"Select * from {entityName} {filter} offset {offset} limit {limit} ";
        }

        public string Update(string entityName, string filter, JObject jObject)
        {
            string result = string.Empty;
            List<string> UpdateItems = new List<string>();
            List<string> columns;
            Dictionary<string, object> valuesToInsert;
            Dictionary<string, JTokenType> typesLookUp;

            ExtractJsonObjectData(jObject, out columns, out valuesToInsert, out typesLookUp);

            foreach (var item in typesLookUp)
            {
                var value = string.Empty;
                value = ValuesCasting(valuesToInsert, item);
                UpdateItems.Add($"{item.Key}={value}");
            }

            return $"update {entityName} Set {string.Join(",", UpdateItems)} where {filter} ";
        }

        public string ValuesCasting(Dictionary<string, object> valuesToInsert, KeyValuePair<string, JTokenType> item)
        {
            string value;
            if (item.Value == JTokenType.Integer || item.Value == JTokenType.Float)
            {
                value = valuesToInsert[item.Key].ToString();
            }
            else
            {
                value = $"'{valuesToInsert[item.Key].ToString()}'";
            }

            return value;
        }
    }
}