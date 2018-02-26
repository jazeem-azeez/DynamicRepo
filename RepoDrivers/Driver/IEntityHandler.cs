using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public interface IEntityHandler<out T> where T : class, IStoreMechanismDescriptor
    {
        T StoreMechnismDesciptor { get; }
        JToken Delete(string entityName, string filter);

        JToken Get(string entityName);

        JToken Get(string entityName, string filter, int offset, int limit);

        JToken Post(string entityName, JObject value);

        JToken Put(string entityName, string filter, JObject value);
        void SetStoreMechanismDescriptor(IStoreMechanismDescriptor mechanismDescriptor);
    }
}