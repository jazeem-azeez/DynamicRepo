using DynamicRepo.Contracts.Business.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace DynamicRepo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{mechanism}/storeGroup/{storeGroup}/entities/{entityName}")]
    public class EntityController : Controller
    {
        private readonly IEntityBusiness _biz;

        public EntityController(IEntityBusiness biz)
        {
            this._biz = biz;
        }
        [HttpPost]
        public Task<bool> CreateEntityAsync([FromBody] JObject jObjectCreatePayLoad,
                                                [FromRoute] string mechanism,
                                                [FromRoute] string storeGroup,
                                                [FromRoute] string entityName)
        {
            Contract.Requires(jObjectCreatePayLoad != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(mechanism));
            return _biz.CreateEntity(jObjectCreatePayLoad, storeGroup, mechanism,entityName );
        }
        [HttpPost]
        [Route("{attributeName}")]
        public Task<bool> CreateEntityAsync([FromBody] JObject jObjectCreatePayLoad,
                                               [FromRoute] string mechanism,
                                               [FromRoute] string storeGroup,
                                               [FromRoute] string entityname,
                                               [FromRoute]string attributeName)
        {
            Contract.Requires(jObjectCreatePayLoad != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(mechanism));
            return _biz.CreateEntity(jObjectCreatePayLoad, storeGroup, mechanism,entityname ,attributeName);
        }

    }
}