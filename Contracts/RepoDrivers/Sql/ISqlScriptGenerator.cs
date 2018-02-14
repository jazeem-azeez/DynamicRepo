using Newtonsoft.Json.Linq;

namespace RepoDrivers.Sql.Shared
{
    public interface ISqlEntityScriptGenerator
    {
        string CreateAndInsert(JObject jObject, string entityName);

        string Delete(string entityName, string filter);

        string Retrive(string entityName, string filter, int offset, int limit);

        string Update(string entityName, string filter, JObject jObject);
    }
}