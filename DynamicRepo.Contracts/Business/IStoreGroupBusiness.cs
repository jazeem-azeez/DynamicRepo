using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DynamicRepo.Contracts.Business
{
    public interface IStoreGroupBusiness
    {
        Task<bool> CreateDataStore(JObject StoreCreatejObject,string mechanism);

        bool EventSubscriptionRegistration(JObject EventFilterExpression);

        bool RemoveStore(string StoreId);
        bool ValidateMechanism(string mechanism);

        
    }
}