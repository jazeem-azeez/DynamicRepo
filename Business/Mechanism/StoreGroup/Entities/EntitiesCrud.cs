using Contracts.Mechanism.StoreGroup.Entities;
using Newtonsoft.Json.Linq;

namespace Bussines.Mechanism.StoreGroup.Entities
{
    public class EntitiesCrud : IEntitiesCrud
    {
        public EntitiesCrud()
        {
        }

        public JObject Delete(string mechanism, 
                              string entityName,
                              string storegroupName,
                              string filter)
        {
            return null;
        }

        public JObject Get(string mechanism,
                                        string storegroupName,
                                        string entityName)
        {
            return null;
        }

        public JObject Get(string mechanism,
                           string storegroupName,
                           string entityName,
                           string filter,
                           int offset,
                           int limit)
        {
            return null;
        }

        public JObject Post(string mechanism,
                            string storegroupName,
                            string entityName,
                            JObject value)
        {
            return null;
        }

        public JObject Put(string mechanism,
                           string storegroupName,
                           string entityName,
                           string filter,
                          JObject value)
        {
            return null;
        }
    }
}