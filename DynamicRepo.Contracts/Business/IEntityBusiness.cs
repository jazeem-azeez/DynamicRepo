using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DynamicRepo.Contracts.Business.Entity
{
    public interface IEntityBusiness
    {
        Task<bool> CreateEntity(JObject jObjectCreatePayLoad, string storeGroup, string mechanism, string entityname, string attributeName);
        Task<bool> CreateEntity(JObject jObjectCreatePayLoad, string storeGroup, string mechanism, string entityname);
    }
}