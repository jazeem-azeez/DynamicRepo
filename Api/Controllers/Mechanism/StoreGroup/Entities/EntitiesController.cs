using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Api.Controllers.Mechanism.StoreGroup.Entities
{
    [Route("api/v1/mechanism/{mechanism}/storegroups/{storegroupName}/entities")]
    public class EntitiesController : Controller
    {
        [HttpDelete("{entityName}")]
        public object Delete([FromRoute] string entityName,
                             [FromQuery] string filter)
        {
            return "";
        }

        [HttpGet]
        public IEnumerable<string> Get([FromRoute]string mechanism,
                                       [FromRoute] string storegroupName,
                                       [FromRoute] string entityName)
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{entityName}")]
        public object Get([FromRoute]string mechanism,
                          [FromRoute] string storegroupName,
                          [FromRoute] string entityName,
                          [FromQuery] string filter,
                          [FromQuery] int offset,
                          [FromQuery] int limit)
        {
            return "value";
        }

        [HttpPost]
        [Route("{entityName}")]
        public object Post([FromRoute]string mechanism,
                           [FromRoute] string storegroupName,
                           [FromRoute] string entityName,
                           [FromBody] JObject value)
        {
            return "";
        }

        [HttpPut]
        [Route("{entityName}")]
        public object Put([FromRoute]string mechanism,
                          [FromRoute] string storegroupName,
                          [FromRoute] string entityName,
                          [FromQuery] string filter,
                          [FromBody]JObject value)
        {
            return "";
        }
    }
}