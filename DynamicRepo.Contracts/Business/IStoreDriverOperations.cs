using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DynamicRepo.Contracts.Business
{
    public interface IStoreDriverOperations
    {
        Task<bool> CreateDataStore(JObject storeCreatejObject, IStoreConnection connection );

        Task<bool> CreateEntiyGroup(JObject entityGroupCreationjObject,IStoreConnection connection );

        JObject DeleteEntities(JObject EntitiesFilterExpresion);

        bool EventSubscriptionRegistration(JObject EventFilterExpression);

        bool RemoveStore(string StoreId);

        JObject RetriveEntities(JObject EntitiesFilterExpresion);

        bool StoreEntity(JObject entityGroupCreationjObject, IStoreConnection connection);

        JObject UpdateEntities(JObject EntitiesFilterExpresion, JObject UpdatePayLoad);
        Task<bool> CreateEntiyGroup(JObject jObjectCreatePayLoad);
        Task<bool> CreateEntiyGroup(JObject jObjectCreatePayLoad, string entityname, string attributeName, IStoreConnection connection);
        Task<bool> CreateEntiyGroup(JObject jObjectCreatePayLoad, string entityname, IStoreConnection connection);
    }
}