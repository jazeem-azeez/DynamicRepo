using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Api.Controllers.Mechanism.StoreGroup.Entities
{
    public interface IEntitiesAPI
    {
        object Delete([FromRoute] string mechanism, [FromRoute] string storegroupName, [FromRoute] string entityName, [FromQuery] string filter);
        object Get([FromRoute] string mechanism, [FromRoute] string storegroupName, [FromRoute] string entityName);
        object Get([FromRoute] string mechanism, [FromRoute] string storegroupName, [FromRoute] string entityName, [FromQuery] string filter, [FromQuery] int offset = 0, [FromQuery] int limit = 1000);
        object Post([FromRoute] string mechanism, [FromRoute] string storegroupName, [FromRoute] string entityName, [FromBody] JObject value);
        object Put([FromRoute] string mechanism, [FromRoute] string storegroupName, [FromRoute] string entityName, [FromQuery] string filter, [FromBody] JObject value);
    }
}