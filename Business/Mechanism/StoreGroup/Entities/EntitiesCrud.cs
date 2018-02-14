using Contracts.Mechanism.StoreGroup.Entities;
using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;

namespace Bussines.Mechanism.StoreGroup.Entities
{
    public class EntitiesCrud : IEntitiesCrud
    {
        private readonly IDynaRepoDriverFactory _factory;

        public EntitiesCrud(IDynaRepoDriverFactory factory)
        {
            this._factory = factory;
        }

        public JObject Delete(string mechanism,
                              string entityName,
                              string storegroupName,
                              string filter)
        {
            var repoDriver = _factory.GetRepoDriver(mechanism, storegroupName);
            return repoDriver.GetEntityHandler().Delete(entityName, filter);
        }

        public JObject Get(string mechanism,
                                        string storegroupName,
                                        string entityName)
        {
            var repoDriver = _factory.GetRepoDriver(mechanism, storegroupName);
            return repoDriver.GetEntityHandler().Get(entityName);
        }

        public JObject Get(string mechanism,
                           string storegroupName,
                           string entityName,
                           string filter,
                           int offset,
                           int limit)
        {
            var repoDriver = _factory.GetRepoDriver(mechanism, storegroupName);
            return repoDriver.GetEntityHandler().Get(entityName, filter, offset, limit);
        }

        public JObject Post(string mechanism,
                            string storegroupName,
                            string entityName,
                            JObject value)
        {
            var repoDriver = _factory.GetRepoDriver(mechanism, storegroupName);
            return repoDriver.GetEntityHandler().Post(entityName, value);
        }

        public JObject Put(string mechanism,
                           string storegroupName,
                           string entityName,
                           string filter,
                          JObject value)
        {
            var repoDriver = _factory.GetRepoDriver(mechanism, storegroupName);
            return repoDriver.GetEntityHandler().Put(entityName, filter, value);
        }
    }
}