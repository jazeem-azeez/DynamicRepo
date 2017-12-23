using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DynamicRepo.Api.Controllers
{
    [Route("api/[controller]")]
    public class DynamicRepoController : Controller
    {
        private readonly IConfiguration config;

        public DynamicRepoController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet("intro")]
        public string Get()
        {
            var intro = config.GetValue<string>("DynamicRepoIntro");
            return string.IsNullOrEmpty(intro) ? "Dynamic Repo is a simple crud store wrapper" : intro;
        }

        [HttpGet]
        [Route("get-all-mechanisms")]
        public object GetMechanisms()
        {
            var temp = config.GetSection("AppSettings:Mechanisms");
            return temp;
        }
    }
}