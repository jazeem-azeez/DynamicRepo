using Contracts.Mechanism.StoreGroup.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Api.Controllers.Mechanism.StoreGroup.Entities
{
    [Route("api/v1/mechanism/{mechanism}/storegroups/{storegroupName}/entities")]
    public class EntitiesController : Controller
    {
        private IEntitiesCrud _entitiesCrud;

        public EntitiesController(IEntitiesCrud entitiesCrud)
        {
            this._entitiesCrud = entitiesCrud;
        }

        [HttpDelete("{entityName}")]
        public object Delete([FromRoute]string mechanism,
                             [FromRoute] string storegroupName,
                             [FromRoute] string entityName,
                             [FromQuery] string filter)
        {
            return _entitiesCrud.Delete(mechanism, entityName, storegroupName, filter);
        }

        [HttpGet]
        public object Get([FromRoute]string mechanism,
                                       [FromRoute] string storegroupName,
                                       [FromRoute] string entityName)
        {
            return _entitiesCrud.Get(mechanism, storegroupName, entityName);
        }

        [HttpGet]
        [Route("{entityName}")]
        public object Get([FromRoute]string mechanism,
                          [FromRoute] string storegroupName,
                          [FromRoute] string entityName,
                          [FromQuery] string filter,
                          [FromQuery] int offset=0,
                          [FromQuery] int limit=1000)
        {
            return _entitiesCrud.Get(mechanism, storegroupName, entityName, filter, offset, limit);
        }

        [HttpPost]
        [Route("{entityName}")]
        public object Post([FromRoute]string mechanism,
                           [FromRoute] string storegroupName,
                           [FromRoute] string entityName,
                           [FromBody] JObject value)
        {
            return _entitiesCrud.Post(mechanism, storegroupName, entityName, value);
        }

        [HttpPut]
        [Route("{entityName}")]
        public object Put([FromRoute]string mechanism,
                          [FromRoute] string storegroupName,
                          [FromRoute] string entityName,
                          [FromQuery] string filter,
                          [FromBody]JObject value)
        {
            return _entitiesCrud.Put(mechanism, storegroupName, entityName, filter, value);
        }
    }
}