using Newtonsoft.Json.Linq;

namespace Contracts.Mechanism.StoreGroup.Entities
{
    public interface IEntitiesCrud
    {
        JToken Delete(string mechanism, string entityName, string storegroupName, string filter);

        JToken Get(string mechanism, string storegroupName, string entityName);

        JToken Get(string mechanism, string storegroupName, string entityName, string filter, int offset, int limit);

        JToken Post(string mechanism, string storegroupName, string entityName, JObject value);

        JToken Put(string mechanism, string storegroupName, string entityName, string filter, JObject value);
    }
}