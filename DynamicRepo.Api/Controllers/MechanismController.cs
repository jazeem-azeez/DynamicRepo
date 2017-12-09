using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DynamicRepo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/mechanism")]
    public class MechanismController : Controller
    {
        private IConfiguration config;

        public MechanismController(IConfiguration config)
        {
            this.config = config;
        }
        [HttpGet]
        [Route("getall")]
        public object GetMechanisms()
        {
            var temp = config.GetSection("AppSettings:Mechanisms");
            return temp;
        }
    }
}