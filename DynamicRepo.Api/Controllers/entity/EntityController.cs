using Microsoft.AspNetCore.Mvc;

namespace DynamicRepo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{mechanism}/{storegroup}/entities/{entity}")]
    public class EntityController : Controller
    {
    }
}