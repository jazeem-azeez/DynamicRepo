using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRepo.Contracts.Business
{
    public interface IStoreDriverOperations
    {
        bool CreateEntiyGroup(JObject entityGroupCreationjObject);
        bool StoreEntity(JObject entityGroupCreationjObject);
        Task<bool> CreateDataStore(JObject StoreCreatejObject);
        bool RemoveStore(string StoreId);
        JObject RetriveEntities(JObject EntitiesFilterExpresion);
        JObject UpdateEntities(JObject EntitiesFilterExpresion, JObject UpdatePayLoad);
        JObject DeleteEntities(JObject EntitiesFilterExpresion);
        bool EventSubscriptionRegistration(JObject EventFilterExpression);
    }
}
