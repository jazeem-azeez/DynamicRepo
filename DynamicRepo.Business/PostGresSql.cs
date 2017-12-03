using DynamicRepo.Common.Models;
using System;
using System.Linq;
using System.Text;

namespace DynamicRepo.Business
{
    public class PostGresSql
    {
        public PostGresSql()
        {

        }
        public string CreateTableScriptGenerator(CreateEntityModel createEntityModel)
        {
            string result = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"CREATE TABLE public.\"{createEntityModel.EntityName}\"");
            stringBuilder.AppendLine($"(");
            string[] attributeString = new string[createEntityModel.AttributesCollection.Count];
            int i = 0;
            foreach (var item in createEntityModel.AttributesCollection)
            {
                attributeString[i]=($" {item.AttributeName} {string.Join(" ", item.Properties)} \r\n");
                i++;
            }
            stringBuilder.AppendLine(string.Join(", ", attributeString));
            stringBuilder.AppendLine($"Constraint {string.Join(",\r\n Constraint ", createEntityModel.Constraints)}");

            stringBuilder.AppendLine($")");
            result = stringBuilder.ToString();
            return result;
        }
    }
}
