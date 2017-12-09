using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        [HttpGet("")]
        public string Get()
        {
            var intro = config.GetValue<string>("DynamicRepoIntro");
            return string.IsNullOrEmpty(intro)?"Dynamic Repo is a simple crud store wrapper":intro;
        }
    }

}
