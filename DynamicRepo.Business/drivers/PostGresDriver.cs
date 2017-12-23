using DynamicRepo.Contracts.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DynamicRepo.Business.drivers
{
    public class PostGresDriver : IStoreDriverOperations
    {
        public Task<bool> CreateDataStore(JObject StoreCreatejObject)
        {
            throw new NotImplementedException();
        }

        public bool CreateEntiyGroup(JObject entityGroupCreationjObject)
        {
            throw new NotImplementedException();
        }

        public JObject DeleteEntities(JObject EntitiesFilterExpresion)
        {
            throw new NotImplementedException();
        }

        public bool EventSubscriptionRegistration(JObject EventFilterExpression)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStore(string StoreId)
        {
            throw new NotImplementedException();
        }

        public JObject RetriveEntities(JObject EntitiesFilterExpresion)
        {
            throw new NotImplementedException();
        }

        public bool StoreEntity(JObject entityGroupCreationjObject)
        {
            throw new NotImplementedException();
        }

        public JObject UpdateEntities(JObject EntitiesFilterExpresion, JObject UpdatePayLoad)
        {
            throw new NotImplementedException();
        }
    }
}
