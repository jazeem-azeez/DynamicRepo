using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Contracts.Mechanism.StoreGroup.Entities
{
    public interface IEntitiesCrud
    {
        JObject Delete(string mechanism, string entityName, string storegroupName, string filter);
        JObject Get(string mechanism, string storegroupName, string entityName);
        JObject Get(string mechanism, string storegroupName, string entityName, string filter, int offset, int limit);
        JObject Post(string mechanism, string storegroupName, string entityName, JObject value);
        JObject Put(string mechanism, string storegroupName, string entityName, string filter, JObject value);
    }
}