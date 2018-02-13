using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public interface IEntityHandler
    {
        JObject Delete(IStoreMechanismDescriptor mechanism, string entityName, string filter);
        JObject Get(IStoreMechanismDescriptor mechanism, string entityName);
        JObject Get(IStoreMechanismDescriptor mechanism, string entityName, string filter, int offset, int limit);
        JObject Post(IStoreMechanismDescriptor mechanism, string entityName, JObject value);
        JObject Put(IStoreMechanismDescriptor mechanism, string entityName, string filter, JObject value);
    }
}