using DynamicRepo.Contracts.Business;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace DynamicRepo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{mechanism}/storegroups/")]
    public class StoreGroupController : Controller
    {
        public StoreGroupController(IStoreGroupBusiness biz)
        {
            this._biz = biz;
        }

        public IStoreGroupBusiness _biz { get; }

        [Route("")]
        [HttpGet]
        public async Task<object> GetAsync([FromRoute]string storegroup, [FromRoute] string mechanism)
        {
            throw new NotImplementedException();
        }

        [Route("")]
        [HttpPost]
        public async Task<bool> PostAsync([FromBody]JObject createPayLoad, [FromRoute] string mechanism)
        {
            Contract.Requires(createPayLoad != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(mechanism));
            return await _biz.CreateDataStore(createPayLoad, mechanism);
        }
    }
}